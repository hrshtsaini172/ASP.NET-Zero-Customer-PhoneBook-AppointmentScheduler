using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using MyTraining1121AngularDemo.Authorization.Users;
using MyTraining1121AngularDemo.MultiTenancy;

namespace MyTraining1121AngularDemo.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}