using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PromotionEngine.Controllers
{
    public class PromotionEngineController : Controller
    {
        IDictionary<string, int> unitPrice = new Dictionary<string, int>();
        public PromotionEngineController()
        {
            unitPrice.Add("A", 50);
            unitPrice.Add("B", 30);
            unitPrice.Add("C", 20);
            unitPrice.Add("D", 15);
        }
        // GET: PromotionEngine
        public ActionResult Index()
        {
            return View(new PromotionEngineModel());
        }

        [HttpPost]
        public ActionResult Index(PromotionEngineModel p, string calculate)
        {
            IDictionary<string, int> numberOfItems = new Dictionary<string, int>();
            PromotionEngineController sku = new PromotionEngineController();

            numberOfItems.Add("A", Convert.ToInt32(p.A));
            numberOfItems.Add("B", Convert.ToInt32(p.B));
            numberOfItems.Add("C", Convert.ToInt32(p.C));
            numberOfItems.Add("D", Convert.ToInt32(p.D));

            int totalOrderValue = sku.calculateTotalOrderValue(numberOfItems);

            p.Total = totalOrderValue;
            return View(p);
        }

        public int calculateTotalOrderValue(IDictionary<string, int> numberOfItems)
        {
            int valueOfA = promoAValue(numberOfItems["A"], unitPrice["A"]);
            int valueOfB = promoBValue(numberOfItems["B"], unitPrice["B"]);
            int valueOfCD = promoCDValue(numberOfItems["C"], numberOfItems["D"], unitPrice["C"], unitPrice["D"]);

            return (valueOfA + valueOfB + valueOfCD);
        }

        public int promoAValue(int numA, int price)
        {
            int promoA = numA / 3;
            int remA = numA % 3;

            //Promotion - 3 of A's for 130
            int promotion3A = 130;

            // Applying promotion and calculating total value.
            int value = (promoA * promotion3A) + (remA * price);

            return value;
        }

        public int promoBValue(int numB, int price)
        {
            int promoB = numB / 2;
            int remB = numB % 2;

            //Promotion - 2 of B's for 45
            int promotion2B = 45;

            // Applying promotion and calculating total value.
            int value = (promoB * promotion2B) + (remB * price);

            return value;
        }


        public int promoCDValue(int numC, int numD, int priceC, int priceD)
        {
            //Promotion - Pair of C & D for 30
            int promotionCD = 30;

            // Applying promotion and calculating total value.
            int value = 0;
            if (numC == numD)
            {
                value = numC * promotionCD;
            }
            else if (numC == 0 || numD == 0)
            {
                value = (numC * priceC) + (numD * priceD);
            }
            else
            {
                if (numC > numD)
                {
                    value = (numD * promotionCD) + ((numC - numD) * priceC);
                }
                else if (numD > numC)
                {
                    value = (numC * promotionCD) + ((numD - numC) * priceD);
                }
            }

            return value;
        }
    }
}