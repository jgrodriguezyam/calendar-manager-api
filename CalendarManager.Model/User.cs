using CalendarManager.Infrastructure.Utils;
using CalendarManager.Model.Base;
using CalendarManager.Model.Enums;

namespace CalendarManager.Model
{
    public class User : EntityBase, IDeletable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EGenderType GenderType { get; set; }
        public string Email { get; set; }        
        public long CellNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PublicKey { get; set; }
        public string Badge { get; set; }
        public string DeviceId { get; set; }

        public bool IsActive { get; set; }

        #region Methods

        public virtual void EncryptPassword()
        {
            Password = Cryptography.Encrypt(Password);
        }

        public virtual void DecryptPassword()
        {
            Password = Cryptography.Decrypt(Password);
        }

        #endregion
    }
}