using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using DX.Data.Xpo.Identity;
using DevExpress.Xpo;
using DX.Data.Xpo.Identity.Persistent;

namespace WebApiWithXpo.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : XPIdentityUser<XpoApplicationUser>
    {
        public ApplicationUser(XpoApplicationUser source) : base(source)
        { }

        public ApplicationUser(XpoApplicationUser source, int loadingFlags) : base(source, loadingFlags)
        { }

        public ApplicationUser()
        { }
        public override void Assign(object source, int loadingFlags)
        {
            base.Assign(source, loadingFlags);
            //XpoApplicationUser src = source as XpoApplicationUser;
            //if (src != null)
            //{
            //  // additional properties here
            //  this.PropertyA = src.PropertyA;
            //  // etc.             
            //}
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole : XPIdentityRole<XpoApplicationRole>
    {
        public ApplicationRole(XpoApplicationRole source, int loadingFlags) : base(source, loadingFlags)
        { }

        public ApplicationRole(XpoApplicationRole source) : base(source)
        { }

        public ApplicationRole()
        { }
        public override void Assign(object source, int loadingFlags)
        {
            base.Assign(source, loadingFlags);
            //XpoApplicationRole src = source as XpoApplicationRole;
            //if (src != null)
            //{
            //  // additional properties here
            //  this.PropertyA = src.PropertyA;
            //  // etc.             
            //}
        }
    }
    // This class will be persisted in the database by XPO
    // It should have the same properties as the ApplicationUser
    [MapInheritance(MapInheritanceType.ParentTable)]
    public class XpoApplicationUser : XpoDxUser
    {
        public XpoApplicationUser(Session session) : base(session)
        {
        }
        public override void Assign(object source, int loadingFlags)
        {
            base.Assign(source, loadingFlags);
            //ApplicationUser src = source as ApplicationUser;
            //if (src != null)
            //{
            //  // additional properties here
            //  this.PropertyA = src.PropertyA;
            //  // etc.             
            //}
        }
    }
    [MapInheritance(MapInheritanceType.ParentTable)]
    public class XpoApplicationRole : XpoDxRole
    {
        public XpoApplicationRole(Session session) : base(session)
        {
        }
        public override void Assign(object source, int loadingFlags)
        {
            base.Assign(source, loadingFlags);
            //ApplicationUser src = source as ApplicationUser;
            //if (src != null)
            //{
            //  // additional properties here
            //  this.PropertyA = src.PropertyA;
            //  // etc.             
            //}
        }
    }

    public class ApplicationDbContext
    {
        public static DX.Data.Xpo.XpoDatabase Create()
        {
            return new DX.Data.Xpo.XpoDatabase("DefaultConnection");
        }
    }
}