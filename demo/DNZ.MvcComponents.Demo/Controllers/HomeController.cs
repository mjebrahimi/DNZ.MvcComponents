using System;
using Microsoft.AspNetCore.Mvc;

namespace DNZ.MvcComponents.Demo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Noty()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Noty(string _)
        {
            if (Request.IsAjaxRequest())
            {
                return MessageBox.Noty("A message from Server with Ajax request", MessageType.Error);
            }
            else
            {
                MessageBox.Noty("A message from Server", MessageType.Success);
                return View();
            }
        }

        [HttpGet]
        public ActionResult SweetAlert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SweetAlert(string _)
        {
            if (Request.IsAjaxRequest())
            {
                return MessageBox.SweetAlert("A message from Server with Ajax request", type: SweetAlertIcon.Error);
            }
            else
            {
                MessageBox.SweetAlert("A message from Server", type: SweetAlertIcon.Success);
                return View();
            }
        }

        [HttpGet]
        public ActionResult SweetAlertBootstrap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SweetAlertBootstrap(string _)
        {
            if (Request.IsAjaxRequest())
            {
                return MessageBox.SweetAlertBs("A message from Server with Ajax request", type: SweetAlertIcon.Error);
            }
            else
            {
                MessageBox.SweetAlertBs("A message from Server", type: SweetAlertIcon.Success);
                return View();
            }
        }

        [HttpGet]
        public ActionResult BsDialog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BsDialog(string s)
        {
            if (Request.IsAjaxRequest())
            {
                return MessageBox.BsDialog("A message from Server with Ajax request", type: DialogType.Danger);
            }
            else
            {
                MessageBox.BsDialog("A message from Server", type: DialogType.Success);
                return View();
            }
        }

        [HttpGet]
        public ActionResult BootBox()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BootBox(string _)
        {
            if (Request.IsAjaxRequest())
            {
                return MessageBox.BootBox("A message from Server with Ajax request", BootBoxType.Alert);
            }
            else
            {

                MessageBox.BootBox("A message from Server", BootBoxType.Alert);
                return View();
            }
        }

        [HttpGet]
        public ActionResult Toastr()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Toastr(string _)
        {
            if (Request.IsAjaxRequest())
            {
                return MessageBox.Toastr("A message from Server with Ajax request", "Your Title", ToastrType.Error);
            }
            else
            {
                MessageBox.Toastr("A message from Server", type: ToastrType.Success);
                return View();
            }
        }

        [HttpGet]
        public ActionResult Wizard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult WizardValidation()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BootstrapControls()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DatePicker()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Select2()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DataTables()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ICheck()
        {
            return View();
        }

        [HttpGet]
        public ActionResult InputMask()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Uploader()
        {
            return View();
        }

        public int UploadFile()
        {
            return new Random().Next(10, 99);
        }

        [HttpGet]
        public ActionResult Uploader2()
        {
            return View();
        }

        public string UploadFile2()
        {
            System.Threading.Thread.Sleep(3000);
            return "test" + new Random().Next(10, 99);
        }

        [HttpGet]
        public ActionResult Typeahead()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Controls()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Handlebars()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
