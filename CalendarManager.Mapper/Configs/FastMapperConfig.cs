using CalendarManager.DTO.Message.CheckIns;
using CalendarManager.DTO.Message.Friendships;
using FastMapper;
using CalendarManager.DTO.Message.Locations;
using CalendarManager.DTO.Message.SharedLocations;
using CalendarManager.DTO.Message.Users;
using CalendarManager.Infrastructure.Dates;
using CalendarManager.Mapper.Resolvers;

namespace CalendarManager.Mapper.Configs
{
    public static class FastMapperConfig
    {
        public static void Initialize()
        {
            #region User

            TypeAdapterConfig<Model.User, Model.User>
                .NewConfig()
                .IgnoreMember(dest => dest.Id)
                .IgnoreMember(dest => dest.UserName)
                .IgnoreMember(dest => dest.Password)
                .IgnoreMember(dest => dest.PublicKey)
                .IgnoreMember(dest => dest.Badge)
                .IgnoreMember(dest => dest.DeviceId)
                .IgnoreMember(dest => dest.ImagePath)

                .IgnoreMember(dest => dest.CreatedBy)
                .IgnoreMember(dest => dest.CreatedOn)
                .IgnoreMember(dest => dest.ModifiedBy)
                .IgnoreMember(dest => dest.ModifiedOn)
                .IgnoreMember(dest => dest.IsActive);

            TypeAdapterConfig<UserRequest, Model.User>
                .NewConfig();

            TypeAdapterConfig<Model.User, UserResponse>
                .NewConfig()
                .MapFrom(dest => dest.ImagePath, src => MapperResolver.MultimediaPath(src.ImagePath));

            #endregion

            #region Location

            TypeAdapterConfig<Model.Location, Model.Location>
                .NewConfig()
                .IgnoreMember(dest => dest.Id)
                .IgnoreMember(dest => dest.UserId)
                .IgnoreMember(dest => dest.CreatedBy)
                .IgnoreMember(dest => dest.CreatedOn)
                .IgnoreMember(dest => dest.ModifiedBy)
                .IgnoreMember(dest => dest.ModifiedOn)
                .IgnoreMember(dest => dest.IsActive);

            TypeAdapterConfig<LocationRequest, Model.Location>
                .NewConfig();

            TypeAdapterConfig<Model.Location, LocationResponse>
                .NewConfig()
                .MapFrom(dest => dest.StartDate, src => src.StartDate.ToDateString())
                .MapFrom(dest => dest.EndDate, src => src.EndDate.ToDateString());

            #endregion

            #region SharedLocation

            TypeAdapterConfig<Model.SharedLocation, Model.SharedLocation>
                .NewConfig()
                .IgnoreMember(dest => dest.Id)              
                .IgnoreMember(dest => dest.CreatedBy)
                .IgnoreMember(dest => dest.CreatedOn)
                .IgnoreMember(dest => dest.ModifiedBy)
                .IgnoreMember(dest => dest.ModifiedOn)
                .IgnoreMember(dest => dest.IsActive);

            TypeAdapterConfig<SharedLocationRequest, Model.SharedLocation>
                .NewConfig();

            TypeAdapterConfig<Model.SharedLocation, SharedLocationResponse>
                .NewConfig();

            #endregion

            #region CheckIn

            TypeAdapterConfig<Model.CheckIn, Model.CheckIn>
                .NewConfig()
                .IgnoreMember(dest => dest.Id)
                .IgnoreMember(dest => dest.Type)
                .IgnoreMember(dest => dest.CreatedBy)
                .IgnoreMember(dest => dest.CreatedOn)
                .IgnoreMember(dest => dest.ModifiedBy)
                .IgnoreMember(dest => dest.ModifiedOn)
                .IgnoreMember(dest => dest.IsActive);

            TypeAdapterConfig<CheckInRequest, Model.CheckIn>
                .NewConfig()
                .IgnoreMember(dest => dest.Type);

            TypeAdapterConfig<Model.CheckIn, CheckInResponse>
                .NewConfig();

            #endregion

            #region Friendship

            TypeAdapterConfig<Model.Friendship, Model.Friendship>
                .NewConfig()
                .IgnoreMember(dest => dest.Id)
                .IgnoreMember(dest => dest.CreatedBy)
                .IgnoreMember(dest => dest.CreatedOn)
                .IgnoreMember(dest => dest.ModifiedBy)
                .IgnoreMember(dest => dest.ModifiedOn)
                .IgnoreMember(dest => dest.IsActive);

            TypeAdapterConfig<FriendshipRequest, Model.Friendship>
                .NewConfig();

            TypeAdapterConfig<Model.Friendship, FriendshipResponse>
                .NewConfig();

            #endregion
        }
    }
}