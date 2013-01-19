using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataObjects
{
    public class Card
    {
         #region  Fields

        private int cardId;
        private int cardHolderId;
        private string name;
        private string description;
        private DateTime creationDate;
        private DateTime finalDate;

        #endregion
        public Card(string name, int id, int cardHolderID)
        {
            this.name = name;
            this.cardId = id;
            this.cardHolderId = cardHolderID;
        }
        public Card()
        {
        }

        #region Properties

        public int CardId
        {
            get
            {
                return this.cardId;
            }

            set
            {
                this.cardId = value;
            }
        }

        public int CardHolderId
        {
            get
            {
                return this.cardHolderId;
            }

            set
            {
                this.cardHolderId = value;
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

        //public static DAL.DataObjects.Card copyToDataObject(Card domainLayerCard)
        //{
        //    DAL.DataObjects.Card newCard = new DAL.DataObjects.Card();

        //    newCard.CardId = domainLayerCard.CardId;
        //    newCard.Name = domainLayerCard.Name;
        //    newCard.Description = domainLayerCard.Description;
        //    newCard.CreationDate = domainLayerCard.CreationDate;
        //    newCard.FinalDate = domainLayerCard.FinalDate;

        //    return newCard;
        //}

        //public static Card copyFromDataObject(DAL.DataObjects.Card dataObjCard)
        //{
        //    Card newCard = new Card();

        //    newCard.cardId = dataObjCard.CardId;
        //    newCard.name = dataObjCard.Name;
        //    newCard.description = dataObjCard.Description;
        //    newCard.creationDate = dataObjCard.CreationDate;
        //    newCard.finalDate = dataObjCard.FinalDate;

        //    return newCard;

        //}
        #endregion
    }
}
