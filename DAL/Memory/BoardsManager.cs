using System;
using System.Collections.Generic;
using DAL.DataObjects;

namespace DAL.Memory
{
    public class BoardsManager
    {
        private static List<DataObjects.Board> boardList = new List<DataObjects.Board>();
        private static List<DataObjects.CardHolder> cardHolderList = new List<CardHolder>();
        private static List<DataObjects.Card> cardList = new List<Card>();

        public static Board GetBoardByID(int ID)
        {
            return boardList.Find(b => b.BoardId == ID);
        }

        private static void fillBoadList()
        {
            if (boardList != null && boardList.Count != 0)
                return;

            DataObjects.Board board1 = new DAL.DataObjects.Board("patato", "description", 1);
            DataObjects.CardHolder holder11 = new CardHolder("holder11", 1, board1.BoardId);
            DataObjects.CardHolder holder12 = new CardHolder("holder12", 2, board1.BoardId);
            DataObjects.Card card11 = new Card("card111", 1, holder11.CardHolderID);
            DataObjects.Card card12 = new Card("card112", 2, holder12.CardHolderID);
            DataObjects.Card card13 = new Card("card113", 3, holder12.CardHolderID);

            holder11.CardList = new List<Card>();
            holder11.CardList.Add(card11);

            holder12.CardList = new List<Card>();
            holder12.CardList.Add(card12);
            holder12.CardList.Add(card13);

            
            board1.CardHolderList = new List<CardHolder>();
            board1.CardHolderList.Add(holder11);
            board1.CardHolderList.Add(holder12);

            DataObjects.Board board2 = new DataObjects.Board("fire", "description", 2);
            DataObjects.CardHolder holder21 = new CardHolder("holder21", 3, board2.BoardId);
            DataObjects.CardHolder holder22 = new CardHolder("holder22", 4, board2.BoardId);
            DataObjects.Card card21 = new Card("card211", 4, holder21.CardHolderID);
            DataObjects.Card card22 = new Card("card212", 5, holder22.CardHolderID);

            holder21.CardList = new List<Card>();
            holder21.CardList.Add(card21);

            holder22.CardList = new List<Card>();
            holder22.CardList.Add(card22);

            board2.CardHolderList = new List<CardHolder>();
            board2.CardHolderList.Add(holder21);
            board2.CardHolderList.Add(holder22);

            boardList.Add(board1);
            boardList.Add(board2);

            cardHolderList.Add(holder11);
            cardHolderList.Add(holder12);
            cardHolderList.Add(holder21);
            cardHolderList.Add(holder22);

            cardList.Add(card11);
            cardList.Add(card12);
            cardList.Add(card13);
            cardList.Add(card22);
            cardList.Add(card21);
        }

        public static List<Board> GetAllBoards()
        {
            fillBoadList();
            return boardList;
        }

        public static void CreateCardHolder(int boardID, string name)
        {
            Board selecteBoard = boardList.Find(b => b.BoardId == boardID);

            if (selecteBoard == null)
                return;

            if (selecteBoard.CardHolderList == null)
                selecteBoard.CardHolderList = new List<CardHolder>();

            selecteBoard.CardHolderList.Add(new CardHolder(name, cardHolderList.Count + 1, boardID));
        }

        public static List<CardHolder> GetAllCardHoldersByBoardID(int boardID)
        {
            Board selectedBoard = boardList.Find(b => b.BoardId == boardID);

            if (selectedBoard == null)
                return null;

            return selectedBoard.CardHolderList;
        }
        #region CardOperations
        public static bool CreateCard(int boradID, int cardHolderID, Card NewCard)
        {
            Board board = boardList.Find(b => b.BoardId == boradID);

            if(board == null || board.CardHolderList == null || board.CardHolderList.Count == 0)
                return false;

            CardHolder cardHolderToInsertCard = board.CardHolderList.Find(ch => ch.CardHolderID == cardHolderID);

            if (cardHolderToInsertCard == null)
                return false;

            if (cardHolderToInsertCard.CardList == null)
                cardHolderToInsertCard.CardList = new List<Card>();

            NewCard.CardId = cardList.Count + 1;
            cardHolderToInsertCard.CardList.Add(NewCard);


            return true;
        }

        public static bool UpdateCard(Card item)
        {
            Card oldCard = getCardByID(item.CardId);

            if (oldCard == null)
                return false;

            try
            {
                oldCard.CardId = item.CardId;
                oldCard.CardHolderId = item.CardHolderId;
                oldCard.Name = item.Name;
                oldCard.Description = item.Description;
                oldCard.CreationDate = item.CreationDate;
                oldCard.FinalDate = item.FinalDate;

                cardList.Add(item);
                cardList.Remove(oldCard);

                CardHolder holderToUpdate = getCardHolderByID(item.CardHolderId);

                if (holderToUpdate == null || holderToUpdate.CardList == null || holderToUpdate.CardList.Count == 0)
                    return false;

                holderToUpdate.CardList.Add(item);
                holderToUpdate.CardList.Remove(oldCard);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Card getCardByID(int cardId)
        {
            Card card = cardList.Find(c => c.CardId== cardId);

            return card;
        }
        #endregion

        #region CardHolderOperations

        public static bool IncludeCardHolderInBoard(int boardWhitNewCardHolderID, CardHolder NewCardHolder)
        {
            Board board = boardList.Find(b => b.BoardId == boardWhitNewCardHolderID);

            if (board == null)
                return false;

           if (board.CardHolderList == null)
               board.CardHolderList = new List<CardHolder>();

           NewCardHolder.CardHolderID = cardHolderList.Count + 1;
            board.CardHolderList.Add(NewCardHolder);


           return true;
        }

        public static CardHolder getCardHolderByID(int cardHolderId)
        {
            CardHolder cardHolder = cardHolderList.Find(ch => ch.CardHolderID == cardHolderId);

            return cardHolder;
        }

        #endregion

        #region BoardOperations

        public static bool CreateBoard (string name, string description)
        {
            DataObjects.Board newBoard = new DAL.DataObjects.Board(name, description, boardList.Count+1);

            if (newBoard == null)
                return false;

            boardList.Add(newBoard);
            return true;
        }
        #endregion
    }
}
