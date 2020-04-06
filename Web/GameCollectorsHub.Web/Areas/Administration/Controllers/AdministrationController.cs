namespace GameCollectorsHub.Web.Areas.Administration.Controllers
{
    using GameCollectorsHub.Common;
    using GameCollectorsHub.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
