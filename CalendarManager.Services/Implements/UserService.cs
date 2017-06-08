using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CalendarManager.DataAccess.Queries;
using CalendarManager.DataAccess.Repositories;
using CalendarManager.DTO.BaseResponse;
using CalendarManager.DTO.Message.Users;
using CalendarManager.Infrastructure.Exceptions;
using CalendarManager.Infrastructure.Files;
using CalendarManager.Infrastructure.Integers;
using CalendarManager.Infrastructure.Utils;
using CalendarManager.Model;
using CalendarManager.Model.Enums;
using CalendarManager.Services.Interfaces;
using CalendarManager.Services.Validators.Interfaces;
using FastMapper;
using ApplicationException = CalendarManager.Infrastructure.Exceptions.ApplicationException;

namespace CalendarManager.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserQuery _userQuery;
        private readonly IUserRepository _userRepository;
        private readonly IUserValidator _userValidator;
        private readonly IStorageProvider _storageProvider;

        public UserService(IUserQuery userQuery, IUserRepository userRepository, IUserValidator userValidator, IStorageProvider storageProvider)
        {
            _userQuery = userQuery;
            _userRepository = userRepository;
            _userValidator = userValidator;
            _storageProvider = storageProvider;
        }

        public FindUsersResponse Find(FindUsersRequest request)
        {
            try
            {
                _userQuery.Init();
                _userQuery.WithOnlyActivated(true);
                _userQuery.WithFirstName(request.FirstName);
                _userQuery.WithLastName(request.LastName);
                _userQuery.WithGender(request.GenderType.ConvertToEnum<EGenderType>());
                _userQuery.WithEmail(request.Email);
                _userQuery.WithCellNumber(request.CellNumber);
                _userQuery.WithUserName(request.UserName);
                _userQuery.WithDevice(request.Device);
                _userQuery.Sort(request.Sort, request.SortBy);
                var totalRecords = _userQuery.TotalRecords();
                _userQuery.Paginate(request.ItemsToShow, request.Page);
                var users = _userQuery.Execute();

                return new FindUsersResponse
                {
                    Users = TypeAdapter.Adapt<List<UserResponse>>(users),
                    TotalRecords = totalRecords
                };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public CreateResponse Create(UserRequest request)
        {
            try
            {
                var user = TypeAdapter.Adapt<User>(request);
                user.Badge = Guid.NewGuid().ToString();
                _userValidator.ValidateAndThrowException(user, "Base,Create");
                user.EncryptPassword();
                _userRepository.Add(user);
                return new CreateResponse(user.Id);
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse Update(UserRequest request)
        {
            try
            {
                var currentUser = _userRepository.FindBy(request.Id);
                currentUser.ThrowExceptionIfRecordIsNull();
                var userToCopy = TypeAdapter.Adapt<User>(request);
                TypeAdapter.Adapt(userToCopy, currentUser);
                _userValidator.ValidateAndThrowException(currentUser, "Base,Update");
                _userRepository.Update(currentUser);
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public UserResponse Get(GetUserRequest request)
        {
            try
            {
                var user = _userRepository.FindBy(request.Id);
                user.ThrowExceptionIfRecordIsNull();
                return TypeAdapter.Adapt<User, UserResponse>(user);
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse Delete(DeleteUserRequest request)
        {
            try
            {
                var user = _userRepository.FindBy(request.Id);
                user.ThrowExceptionIfRecordIsNull();
                _userRepository.Remove(user);
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public LoginUserResponse Login(LoginUserRequest request)
        {
            try
            {
                var encryptPassword = Cryptography.Encrypt(request.Password);
                var user = _userRepository.FindBy(currentUser => currentUser.UserName == request.UserName && currentUser.Password == encryptPassword).FirstOrDefault();
                user.ThrowExceptionIfIsNull(HttpStatusCode.Unauthorized, "Credenciales invalidas");
                _userValidator.ValidateAndThrowException(user, "LoginValidate");

                return new LoginUserResponse
                {
                    UserId = user.Id
                };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse Logout(LogoutUserRequest request)
        {
            try
            {
                var user = _userRepository.FindBy(request.Id);
                user.ThrowExceptionIfRecordIsNull();
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public SuccessResponse ChangePassword(ChangeUserPasswordRequest request)
        {
            try
            {
                var encryptOldPassword = Cryptography.Encrypt(request.OldPassword);
                var userToUpdate = _userRepository.FindBy(user => user.UserName == request.UserName && user.Password == encryptOldPassword).FirstOrDefault();
                userToUpdate.ThrowExceptionIfIsNull(HttpStatusCode.Unauthorized, "Credenciales invalidas");
                userToUpdate.Password = request.NewPassword;
                userToUpdate.EncryptPassword();
                _userRepository.Update(userToUpdate);
                return new SuccessResponse { IsSuccess = true };
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }

        public AddImageUserResponse AddImage(AddImageUserRequest request, File file)
        {
            try
            {
                var user = _userRepository.FindBy(request.Id);
                var savedFilePath = _storageProvider.Save(file);
                user.ImagePath = savedFilePath;
                _userRepository.Update(user);
                var userResponse = TypeAdapter.Adapt<User, UserResponse>(user);
                return new AddImageUserResponse(userResponse.ImagePath);
            }
            catch (DataAccessException)
            {
                throw new ApplicationException();
            }
        }
    }
}