using DAL.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Card 
    {
        #region Fields

        private int cardID;
        private int cardHolderID;
        private string name;
        private string description;
        private DateTime creationDate;
        private DateTime finalDate;

        #endregion
        #region Propperties
        public int CardID
        {
            get
            {
                return this.cardID;
            }
            set
            {
                this.cardID = value;
            }
        }

        public int CardHolderID
        {
            get
            {
                return this.cardHolderID;
            }
            set
            {
                this.cardHolderID = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public DateTime CreationDate
        {
            get
            {
                return this.creationDate;
            }
            set
            {
                this.creationDate = value;
            }
        }

        public DateTime FinalDate
        {
            get
            {
                return this.finalDate;
            }
            set
            {
                this.finalDate = value;
            }
        }

#endregion
        #region DataPassig Methods

        public static bool CreateCard(Card item, int boardID)
        {
            DAL.DataObjects.Card newCard = copyToDataObject(item);

            return BoardsManager.CreateCard(boardID, item.CardHolderID, newCard);
        }

        public static bool UpdateCard(Card card)
        {
            DAL.DataObjects.Card item = copyToDataObject(card);

            return BoardsManager.UpdateCard(item);
        }

        public static Card GetCardByID(int cardID)
        {
            DAL.DataObjects.Card card = BoardsManager.getCardByID(cardID);

            if (card == null)
                return null;

            return copyFromDataObject(card);  
        }

        public static DAL.DataObjects.Card copyToDataObject(Card domainLayerCard)
        {
            DAL.DataObjects.Card newCard = new DAL.DataObjects.Card();

            newCard.CardId = domainLayerCard.CardID;
            newCard.CardHolderId = domainLayerCard.CardHolderID;
            newCard.Name = domainLayerCard.Name;
            newCard.Description = domainLayerCard.Description;
            newCard.CreationDate = domainLayerCard.CreationDate;
            newCard.FinalDate = domainLayerCard.FinalDate;

            return newCard;
        }

        public static Card copyFromDataObject(DAL.DataObjects.Card dataObjCard)
        {
            Card newCard = new Card();

            newCard.cardID = dataObjCard.CardId;
            newCard.cardHolderID = dataObjCard.CardHolderId;
            newCard.name = dataObjCard.Name;
            newCard.description = dataObjCard.Description;
            newCard.creationDate = dataObjCard.CreationDate;
            newCard.finalDate = dataObjCard.FinalDate;

            return newCard;

        }
        #endregion
    }
}
