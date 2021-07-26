﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_CuoiKy.Models;

namespace Web_CuoiKy.Controllers
{
    public class CartController : Controller
    {
        // GET: Gio_Hang
        Model_SP db = new Model_SP();
        // GET: Cart
        public ActionResult Index()
        {
            return View((List<CartModel>)Session["cart"]);
        }

        public ActionResult AddToCart(int id, int quantity)
        {
            if (Session["cart"] == null)
            {
                List<CartModel> cart = new List<CartModel>();
                cart.Add(new CartModel { San_Pham = db.San_Pham.Find(id), quantity = quantity });
                Session["cart"] = cart;
                Session["count"] = 1;
            }
            else
            {
                List<CartModel> cart = (List<CartModel>)Session["cart"];
                //kiểm tra sản phẩm có tồn tại trong giỏ hàng chưa???
                int index = isExist(id);
                if (index != -1)
                {
                    //nếu sp tồn tại trong giỏ hàng thì cộng thêm số lượng
                    cart[index].quantity += quantity;
                }
                else
                {
                    //nếu không tồn tại thì thêm sản phẩm vào giỏ hàng
                    cart.Add(new CartModel { San_Pham = db.San_Pham.Find(id), quantity = quantity });
                    //Tính lại số sản phẩm trong giỏ hàng
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
                Session["cart"] = cart;
            }
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }

        private int isExist(int id)
        {
            List<CartModel> cart = (List<CartModel>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].San_Pham.MASP.Equals(id))
                    return i;
            return -1;
        }

        //xóa sản phẩm khỏi giỏ hàng theo id
        public ActionResult Remove(int Id)
        {
            List<CartModel> li = (List<CartModel>)Session["cart"];
            li.RemoveAll(x => x.San_Pham.MASP == Id);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }
        public ActionResult UpdateCart (int id,int quantity)
        {
            // Cập nhật Cart thay đổi số lượng quantity ...
            List<CartModel> cart = (List<CartModel>)Session["cart"];
            //kiểm tra sản phẩm có tồn tại trong giỏ hàng chưa???
            int index = isExist(id);
            if (index != -1)
            {
                //nếu sp tồn tại trong giỏ hàng thì cộng thêm số lượng
                cart[index].quantity += quantity;
            }
            else
            {
                //nếu không tồn tại thì thêm sản phẩm vào giỏ hàng
                cart.Add(new CartModel { San_Pham = db.San_Pham.Find(id), quantity = quantity });
                //Tính lại số sản phẩm trong giỏ hàng
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }
            Session["cart"] = cart;
            return Json(new { Message = "Thành công", JsonRequestBehavior.AllowGet });
        }
    }
}