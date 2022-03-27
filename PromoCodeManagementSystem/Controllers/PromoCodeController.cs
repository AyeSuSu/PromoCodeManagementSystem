using Microsoft.AspNetCore.Mvc;
using PromoCodeManagementSystem.Context;
using PromoCodeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PromoCodeManagementSystem.Common;
using PromoCodeManagementSystem.Communication;

namespace PromoCodeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoCodeController : ControllerBase
    {
        private DataContext myDbContext;
        public PromoCodeController(DataContext context)
        {
            myDbContext = context;
        }

        [HttpGet("generate/phoneno/{phoneno}")]
        public async Task<ActionResult> GeneratePromoCode(string phoneno)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                var promoCode = PromocodeGenerate.Generate();

                var promocodeCount = myDbContext.Promocodes.Where(x => x.promocode == promoCode).Count();

                while (promocodeCount > 0)
                {
                    promoCode = PromocodeGenerate.Generate();
                    promocodeCount = myDbContext.Promocodes.Where(x => x.promocode == promoCode).Count();
                }
                PromocodesModel promocodesModel = new PromocodesModel();
                promocodesModel.id = Guid.NewGuid().ToString();
                promocodesModel.promocode = promoCode;
                promocodesModel.phoneNo = phoneno;
                promocodesModel.createdDateTime = DateTime.Now;
                promocodesModel.updatedDateTime = DateTime.Now;
                await myDbContext.Promocodes.AddAsync(promocodesModel);
                await myDbContext.SaveChangesAsync();

                baseResponse.message = "Successfully generate Promocode";
                baseResponse.promocode = promoCode;
                baseResponse.success = true;
                baseResponse.error = false;

            }
            catch (Exception ex)
            {
                baseResponse.message = ex.ToString();
                baseResponse.success = false;
                baseResponse.error = true;
            }
            return Ok(baseResponse);
        }
    }
}
