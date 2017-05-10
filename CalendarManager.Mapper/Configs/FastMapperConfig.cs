using FastMapper;
using CalendarManager.DTO.Message.Locations;
using CalendarManager.DTO.Message.Users;

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

                .IgnoreMember(dest => dest.CreatedBy)
                .IgnoreMember(dest => dest.CreatedOn)
                .IgnoreMember(dest => dest.ModifiedBy)
                .IgnoreMember(dest => dest.ModifiedOn)
                .IgnoreMember(dest => dest.IsActive);

            TypeAdapterConfig<UserRequest, Model.User>
                .NewConfig();

            TypeAdapterConfig<Model.User, UserResponse>
                .NewConfig();

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
                .NewConfig();

            #endregion
        }
    }
}