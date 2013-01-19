using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class BoardController : Controller
    {
        public ActionResult Boards()
        {
            //ViewBag.Message = "Lista de Boards aqui.";
            List<Board> allBoards = getAllBoards();

            return View(allBoards);
        }

        public ActionResult NewBoard()
        {
            Board newBoad = new Board();
            return View("CreateBoard", newBoad);
        }

        [HttpPost]
        public ActionResult SaveBoard(Board newBoard)
        {
            bool sucess = CreateBoard(newBoard);

            if(!sucess)
                return View(); //criar view em shared k recebe a mensagem de erro e apresenta

            List<Board> allBoards = getAllBoards();
            return View("Boards", allBoards);
        }

        public ActionResult PresentBoard(int id)
        {
            Board editBoard = Board.GetBoardByID(id);
            return View("Board", editBoard);
        }

        //public static Board Create()
        //{
        //    return new Board();
        //}

        //public static Board getABoad(int id)
        //{
        //    return Board.GetBoard(id);
        //}

        public static bool CreateBoard(Board item)
        {
            return Board.CreateBoard(item.Name, item.Description);
        }

        public static List<Board> getAllBoards()
        {
            return Board.GetAllBoards();

        }

       
    }
}
