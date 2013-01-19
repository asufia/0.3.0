using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataObjects
{
    public class CardHolder
    {
        private int cardHolderID;
        private int boardID;
        private string name;
        private int stateID;
        private string description;
        private List<Card> cardList;

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

        public CardHolder()
        { }

        public CardHolder(string name, int id, int boardID)
        {
            this.Name = name;
            this.CardHolderID = id;
            this.boardID = boardID;
        }
    }
}
