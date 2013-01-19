using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataObjects
{
    public class Boad 
    {
        #region  Fields

        private int boardId;
        private string name;
        private int stateID;
        private string description;
        private List<CardHolder> cardHolderList;
        #endregion

        #region Properties

        public int BoardId
        {
            get
            {
                return this.boardId;
            }

            set
            {
                this.boardId = value;
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

        public List<CardHolder> CardHolderList
        {
            get
            {
                return this.cardHolderList;
            }

            set
            {
                this.cardHolderList = value;
            }
        }
        #endregion
    }
}
