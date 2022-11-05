using Microsoft.AspNetCore.Mvc;

namespace EPrescribingSystem.Extensions
{
    public enum NotificationType
    {
        success,
        error,
        info
    }
    public class BaseController : Controller
    {
        

        public void BasicNotification()
        {
            TempData["notification"] = $"Swal.fire({{\r\n  position: 'top-end',\r\n  icon: 'success',\r\n  title: 'User successfuly added!',\r\n  showConfirmButton: false,\r\n  timer: 1500\r\n}})";
        }
    }
}
