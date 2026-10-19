using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Dots;
using Product.Model;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameStoreController : ControllerBase
    {
        public static List<Game> lstGame = new List<Game>()
        {
          new Game { QRcode = 6548465468, gameName = "Call Of Duty"         , IsUsed = true , price = 70, place = "2nd" },
          new Game { QRcode = 4556456665, gameName = "Far Cry"              , IsUsed = true , price = 70, place = null  },
          new Game { QRcode = 7898645645, gameName = "Ghost Of Tsushema"    , IsUsed = false, price = 45, place = null  },
          new Game { QRcode = 5434568645, gameName = "Need For Speed "      , IsUsed = false, price = 40, place ="GF"   },
          new Game { QRcode = 9871234567, gameName = "The Witcher 3"        , IsUsed = true , price = 25, place = "1st" },
          new Game { QRcode = 8529637410, gameName = "Red Dead Redemption 2", IsUsed = false, price = 60, place = "GF"  },
          new Game { QRcode = 7418529630, gameName = "Apex Legends"         , IsUsed = false, price = 0 , place = null  },
          new Game { QRcode = 9632587410, gameName = "Dying Light"          , IsUsed = true , price = 30, place = "2nd" },
          new Game { QRcode = 1593574862, gameName = "Resident Evil  2"     , IsUsed = true , price = 20, place = null  },
          new Game { QRcode = 4862159357, gameName = "Minecraft"            , IsUsed = false, price = 30, place = "1st" },
          new Game { QRcode = 2581473690, gameName = "The Finals"           , IsUsed = false, price = 0 , place = null  },
        };

        [HttpGet]

        public IActionResult GetAllGames(bool? used, string? GameName)
        {
            var data = from G in lstGame
                        where (G.IsUsed == used || used == null) && ( GameName == null ||  (G.gameName.ToUpper().Contains(GameName.ToUpper())))
                       orderby G.gameName
                       select new GameDot
                       {
                           gameName = G.gameName,
                           price = G.price,
                           place = G.place,
                           IsUsed = (G.IsUsed == true) ? "Yes":"NO"
                       };

       
            return Ok(data);
        }

        [HttpGet("GetByQRcode")]

        public IActionResult ByQrcode(long QR)
        {
            var QRdata = lstGame.Select
            ( x => new GameDot
            {
                QRcode = x.QRcode,
                gameName = x.gameName,
                price = x.price,
                place = x.place,
                IsUsed = (x.IsUsed == true) ? "Yes" : "NO",
        }).FirstOrDefault(x => x.QRcode == QR);

            if (QRdata == null)
            {
                return NotFound("The Game does not exist.");
            }   

            return Ok(QRdata);


        }

        [HttpPost]

        public IActionResult Insert([FromQuery]InsertGameDot game)
        {
            var newGame = new Game
            {
                QRcode = (lstGame.LastOrDefault()?.QRcode  ?? 0) + 1,
                gameName = game.gameName,
                price = game.price,
                place = game.place,
                IsUsed = game.IsUsed
            };
            lstGame.Add(newGame);
            return Ok(newGame);
        }

        [HttpPut]

        public IActionResult UpdateData(InsertGameDot EditGame )
        {
            
            var EditedGame=lstGame.FirstOrDefault(x=>x.QRcode == EditGame.QRcode);
            if (EditedGame == null)
            {
                return BadRequest(new Exception("The Game does not exist."));
            }
            EditedGame.QRcode=EditGame.QRcode;
            EditedGame.gameName=EditGame.gameName;
            EditedGame.price=EditGame.price;
            EditedGame.place=EditGame.place;
            return Ok();
        }

        [HttpDelete]

        public IActionResult DelGame(long QR)
        {
            var RemoveGame = lstGame.FirstOrDefault(x => x.QRcode == QR);
            if (RemoveGame==null)
            {
                return BadRequest(new Exception("The Game does not exist."));
            }
            lstGame.Remove(RemoveGame);
            return Ok("The game has been deleted.");
        }

    }
}

