using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.DataAccess.Repository.IRepository;
using Store.Models;
using Store.Models.ViewModels;
using System.Security.Claims;

namespace WebStore.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartVM ShoppingCartVM { get; set; }

        public int OrderTotal { get; set; }

        public ShoppingCartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ShoppingCartVM = new ShoppingCartVM()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value, includeProperties: "Product")
            };
            foreach(var cart in ShoppingCartVM.ShoppingCartList)
            {
                ShoppingCartVM.Total += (cart.Product.Price * cart.Count);
            }
            return View(ShoppingCartVM);
        }

        public IActionResult Plus(int ShoppingCartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == ShoppingCartId);
            _unitOfWork.ShoppingCart.AddToCount(cart);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int ShoppingCartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == ShoppingCartId);
            if (cart.Count <= 1)
            {
                _unitOfWork.ShoppingCart.Remove(cart);
            }
            else
            {
                _unitOfWork.ShoppingCart.RemoveFromCount(cart);
            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int ShoppingCartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(u => u.Id == ShoppingCartId);
            _unitOfWork.ShoppingCart.Remove(cart);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
