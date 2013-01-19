using DAL.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class CardHolder
    {
        #region Fields

        private int cardHolderID;
        private int boardID;
        private string name;
        private string description;
        private int stateID;
        private List<Card> cardList;

        #endregion

        #region Properties

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

        public int BoardID
        {
            get
            {
                return this.boardID;
            }
            set
            {
                this.boardID = value;
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

        public int StateID
        {
            get
            {
                return this.stateID;
            }
            set
            {
                this.stateID = value;
            }
        }

        public List<Card> CardList
        {
            get
            {
                return this.cardList;
            }
            set
            {
                this.cardList = value;
            }
        }
        #endregion

        #region  Methots

        public CardHolder()
        { }

        public CardHolder(string name, int boadID)
        {
            this.Name = name;
            BoardsManager.CreateCardHolder(boardID, name);
        }

        public static bool InsertCardHolderInBoard(int boardID, CardHolder cardHolder)
        {
            DAL.DataObjects.CardHolder newCardHolder = copyToDataObject(cardHolder);

            return BoardsManager.IncludeCardHolderInBoard(boardID, newCardHolder);
        }

        public static List<CardHolder> GetAllCardHoldersByBoardID(int boardID)
        {
            List<DAL.DataObjects.CardHolder> dataList = BoardsManager.GetAllCardHoldersByBoardID(boardID);

            if (dataList == null)
                return null;
            List<CardHolder> cardHolderList = new List<CardHolder>();

            foreach (DAL.DataObjects.CardHolder dataCardHolder in dataList)
            {
                CardHolder newCardHolder = copyFromDataObject(dataCardHolder);

                cardHolderList.Add(newCardHolder);
            }

            return cardHolderList;
        }

        public static CardHolder getCardHolderByID(int cardHolderID)
        {
            DAL.DataObjects.CardHolder cardHolder = BoardsManager.getCardHolderByID(cardHolderID);

            if (cardHolder == null)
                return null;

            return copyFromDataObject(cardHolder);  
        }

        private static DAL.DataObjects.CardHolder copyToDataObject(CardHolder domainLayerCardHolder)
        {
            DAL.DataObjects.CardHolder newCardHolder = new DAL.DataObjects.CardHolder();

            newCardHolder.CardHolderID = domainLayerCardHolder.CardHolderID;
            newCardHolder.BoardID = domainLayerCardHolder.BoardID;
            newCardHolder.Name = domainLayerCardHolder.Name;
            newCardHolder.StateID = domainLayerCardHolder.StateID;
            newCardHolder.Description = domainLayerCardHolder.Description;

            if (domainLayerCardHolder.CardList != null && domainLayerCardHolder.CardList.Count > 0)
            {
                newCardHolder.CardList = new List<DAL.DataObjects.Card>();

                foreach (Card card in domainLayerCardHolder.CardList)
                {
                    newCardHolder.CardList.Add(Card.copyToDataObject(card));
                }
            }

            return newCardHolder;
        }

        private static CardHolder copyFromDataObject(DAL.DataObjects.CardHolder dataObjCardHolder)
        {
            CardHolder newCardHolder = new CardHolder();

            newCardHolder.CardHolderID = dataObjCardHolder.CardHolderID;
            newCardHolder.boardID = dataObjCardHolder.BoardID;
            newCardHolder.name = dataObjCardHolder.Name;
            newCardHolder.stateID = dataObjCardHolder.StateID;
            newCardHolder.description = dataObjCardHolder.Description;

            if (dataObjCardHolder.CardList != null && dataObjCardHolder.CardList.Count > 0)
            {
                newCardHolder.CardList = new List<Card>();

                foreach (DAL.DataObjects.Card card in dataObjCardHolder.CardList)
                {
                    newCardHolder.CardList.Add(Card.copyFromDataObject(card));
                }
            }

            return newCardHolder;

        }
          
        #endregion

    }
}
