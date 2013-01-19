using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class CardController : Controller
    {
        #region fields
        private static int cardHolderID;
        private static int boardID;

        #endregion
        #region ViewMethods

        public ActionResult NewCard(int id)
        {
            CardHolder cardHolder = CardHolder.getCardHolderByID(id);

            if (cardHolder == null)
                return View("Error"); 

            boardID = cardHolder.BoardID;
            cardHolderID = id;
            Card card = new Card();
            return View("CreateCard", card);
        }

        public ActionResult EditCard(int id)
        {
            Card card = Card.GetCardByID(id);

            if (card == null)
                return View("Error"); //Erro

            cardHolderID = card.CardHolderID;

            CardHolder ch = CardHolder.getCardHolderByID(cardHolderID);

            if (ch == null)
                return View("Error"); //Erro

            boardID = ch.BoardID;

            return View("EditCard", card);

        }

        public ActionResult UpdateCard(Card card, int id)
        {
            card.CardID = id;
            card.CardHolderID = cardHolderID;

            if (!Card.UpdateCard(card))
                return View("Error");

            return RedirectToAction("PresentBoard", "Board", new { id = boardID });
        }
        public ActionResult SaveCard(Card newCard)
        {
            newCard.CardHolderID = cardHolderID;

            Card.CreateCard(newCard, boardID);

            return RedirectToAction("PresentBoard", "Board", new { id = boardID });
        }

        #endregion

        #region BusinessMethods
        //private void AddCardHolderToBoard(Board cardHolderToInsertInBoard)
        //{ 

        //}
        #endregion
    }
}
