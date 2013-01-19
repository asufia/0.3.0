using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class CardHolderController : Controller
    {
        public static CardHolder CreateCardHolder(string name, int boardID)
        {
            return new CardHolder(name, boardID);
        }

        public static List<CardHolder> GetAllCardHolders(int bordID)
        {
            return CardHolder.GetAllCardHoldersByBoardID(bordID);

        }

        #region ViewMethods
        private static int BoardID = 0;

        [HttpPost]
        public ActionResult NewCardHolder(int id)
        {
            BoardID = id;
            CardHolder cardHolder = new CardHolder();
            cardHolder.BoardID = id;
            return View("CreateCardHolder", cardHolder);
        }

        //public ActionResult PresentCardHolder(int boardId, int cardHolderId)
        //{
        //    CardHolder editCardHolder = CardHolder.getCardHolderByID(cardHolderId, boardId);
        //    return View("CardHolder");
        //}

        public ActionResult SaveCardHolder(CardHolder newCardHolder)
        {
            newCardHolder.BoardID = BoardID;

            AddCardHolderToBoard(newCardHolder);

            return RedirectToAction("PresentBoard", "Board", new { id = BoardID });
        }

        #endregion

        #region BusinessMethods
        private void AddCardHolderToBoard(CardHolder newCardHolder)
        {
            CardHolder.InsertCardHolderInBoard(newCardHolder.BoardID, newCardHolder);
        }
        #endregion
        
    }
}
