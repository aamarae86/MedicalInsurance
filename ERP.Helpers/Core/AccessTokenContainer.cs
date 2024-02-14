using Abp.Runtime.Security;

namespace ERP.Front.Helpers.Core
{
    public class AccessTokenContainer
    {
        public  string EncryptedToken { private get; set; }
        public  string DecryptedToken 
        {
            get {
                return SimpleStringCipher.Instance.Decrypt(EncryptedToken,AppConsts.DefaultPassPhrase);
            }
        }

        public  int TenantId { get; set; } = -1;
    }
}
