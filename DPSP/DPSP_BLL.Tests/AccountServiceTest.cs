//using DPSP_API.Controllers;
//using DPSP_BLL.Models;
//using DPSP_DAL;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http;
////using System.Net.Http;

//namespace DPSP_BLL.Tests
//{
//    [TestClass]
//    public class AccountServiceTest : ApiController
//    {
//        private ApplicationUserManager _userManager;
//        //private Mock<IUserService> _userService;
//        private IOwinContext _context;
//        private IUserService _userService;
//        private IAccountService _accountService;

//        public ApplicationUserManager UserManager
//        {
//            get
//            {
//                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
//            }
//            private set
//            {
//                _userManager = value;
//            }
//        }

//        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
//        {
//            public ApplicationDbContext()
//                : base("DefaultConnection", throwIfV1Schema: false)
//            {
//            }

//            public static ApplicationDbContext Create()
//            {
//                return new ApplicationDbContext();
//            }
//        }

//        public AccountServiceTest()
//        {

//        }
//        public AccountServiceTest(IUserService userService, IAccountService accountService)
//        {
//            _userService = userService;
//            _accountService = accountService;
//        }

//        [TestInitialize]
//        public void Initialize()
//        {
//            var userStore = new Mock<IUserStore<ApplicationUser>>();
//            //_userManager = new Mock<ApplicationUserManager>(userStore.Object);
//            //_userService = new Mock<IUserService>();
//            //_userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

//        }

//        //[TestMethod]
//        //public async Task CreationTest()
//        //{
//        //    // //var mock = new Mock<BaseTestController>();
//        //    // //mock.CallBase = true;
//        //    // //var ta = mock.Object;

//        //    //// ta.ControllerContext = new HttpControllerContext { Request = new HttpRequestMessage() };
//        //    // var owinMock = new Mock<IOwinContext>();

//        //    // var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
//        //    // userStoreMock.Setup(s => s.FindByIdAsync("testId")).ReturnsAsync(new ApplicationUser
//        //    // {
//        //    //     Id = "testId",
//        //    //     Email = "test@email.com"
//        //    // });
//        //    // var applicationUserManager = new ApplicationUserManager(userStoreMock.Object);

//        //    // owinMock.Setup(o => o.Get<ApplicationUserManager>(It.IsAny<string>())).Returns(applicationUserManager);

//        //    // //ta.Request.SetOwinContext(owinMock.Object);

//        //    //var owinContext = new OwinContext();
//        //    //var userStore = new UserStore<ApplicationUser>(owinContext.Get<ApplicationDbContext>());
//        //    //var userManager = new ApplicationUserManager(userStore);

//        //    var model = new CreateUserBindingModel
//        //    {
//        //        //Email = $"test@{Guid.NewGuid()}.test",
//        //        Email = "psprynar@deloittece.com",
//        //        FirstName = "FirstName",
//        //        LastName = "LastName",
//        //        Role = nameof(RoleType.Employee)
//        //    };

//        //    var service = new DPSP_BLL.AccountService(_userService.Object);
//        //    await service.Creation(model, /*applicationUserManager*//*_userManager.Object*/ _userManager, new Uri("https://testuri.test"));

//        //}

//        [TestMethod]
//        public async Task CreationTest2()
//        { // Arrange 
//            var controller = new AccountController(_userService, _accountService);
//            controller.Request = new HttpRequestMessage();
//            controller.Configuration = new HttpConfiguration();
//            // Act
//            var model = new CreateUserBindingModel
//            {
//                //Email = $"test@{Guid.NewGuid()}.test",
//                Email = "psprynar@deloittece.com",
//                FirstName = "FirstName",
//                LastName = "LastName",
//                Role = nameof(RoleType.Employee)
//            };
//            var response = await controller.Creation(model);
//            // Assert 
//            //Assert.IsTrue(response.TryGetContentValue<Product>(out product));
//            //Assert.AreEqual(10, product.Id);
//        }
//    }
//}
