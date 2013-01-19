using DAL.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Board
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

        #region Methods

        public Board()
        {
        }


        public static List<Board> GetAllBoards()
        {
            List<DAL.DataObjects.Board> dataList =BoardsManager.GetAllBoards();

            if(dataList == null)
                return null;

            List<Board> boardList = new List<Board>();

            foreach (DAL.DataObjects.Board dataBoard in dataList)
            {
                Board newBoard = new Board();

                newBoard.boardId = dataBoard.BoardId;
                newBoard.name = dataBoard.Name;
                newBoard.description = dataBoard.Description;
                newBoard.stateID = dataBoard.StateID;

                if (dataBoard.CardHolderList != null && dataBoard.CardHolderList.Count > 0)
                {
                    newBoard.cardHolderList = CardHolder.GetAllCardHoldersByBoardID(dataBoard.BoardId); 
                }

                boardList.Add(newBoard);
            }

            return boardList;
        }

        public static bool CreateBoard(string name, string description)
        {
            return BoardsManager.CreateBoard(name, description);
        }

        public static void CreateCardHolder(int boardID, string name)
        {
            BoardsManager.CreateCardHolder(boardID, name);
        }

        public static bool UpDateBoard(int boardID)
        {
            return true;
        }

        public static bool RemoveBoard(int boardID)
        {
            return true;
        }

        public static Board GetBoardByID(int id)
        {
            DAL.DataObjects.Board dalBoard = BoardsManager.GetBoardByID(id);

            if (dalBoard == null)
                return null;

            Board boardToReturn = copyFromDataObject(dalBoard);
            return boardToReturn;
        }

        private static DAL.DataObjects.Board copyToDataObject(Board domainLayerBoard)
        {
            DAL.DataObjects.Board newBoard = new DAL.DataObjects.Board();

            newBoard.BoardId = domainLayerBoard.BoardId;
            newBoard.Name = domainLayerBoard.Name;
            newBoard.StateID = domainLayerBoard.StateID;
            newBoard.Description = domainLayerBoard.Description;

            return newBoard;
        }

        private static Board copyFromDataObject(DAL.DataObjects.Board dataObjBoard)
        {
            Board newBoard = new Board();

            newBoard.boardId = dataObjBoard.BoardId;
            newBoard.name = dataObjBoard.Name;
            newBoard.stateID = dataObjBoard.StateID;
            newBoard.description = dataObjBoard.Description;

            if (dataObjBoard.CardHolderList != null && dataObjBoard.CardHolderList.Count > 0)
                newBoard.CardHolderList = CardHolder.GetAllCardHoldersByBoardID(dataObjBoard.BoardId);

            return newBoard;

        }
        #endregion

    }

}
