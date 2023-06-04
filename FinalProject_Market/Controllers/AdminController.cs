//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AppCore.AppServices.Admin.Command;
//using AppCore.AppServices.Admin.Query;
//using AppCore.AppServices.Admin_.Command;
//using AppCore.AppServices.Admin_.Query;
//using AppCore.DtoModels;
//using AppCore.DtoModels.Admin;
//using AppCore.DtoModels.Auction;
//using AppCore.DtoModels.Customer;
//using AppCore.DtoModels.DirectOrder;
//using AppCore.DtoModels.Product;
//using AppCore.DtoModels.Seller;
//using AppService.Admin;
//using AppService.Admin.Commands;
//using AppService.Admin.Queries;
//using AutoMapper;
//using FinalProject_Market.Models;
//using FinalProject_Market.Models.ViewModels;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace FinalProject_Market.Controllers
//{
//    public class AdminController : Controller
//    {
//        #region field
//        private readonly IGetCustomer _customer;
//        private readonly IEditCustomer _editCustomer;
//        private readonly IEditSeller _editSeller;
//        private readonly IDeactiveUser _deactiveUser;


//        private readonly IGetAllSellerProducts _sellerProducts;
//        private readonly IGetSellerPavilions _sellerPavilions;
//        private readonly IGetAllAuctions _auctions;
//        private readonly IGetAllPaidOrders _paidOrders;
//        private readonly IDeactiveProduct _deactiveProduct;
//        private readonly IEditProduct _editProduct;
//        private readonly IActiveProduct _activeProduct;
//        private readonly IGetAuction _getAuction;
//        private readonly AppService.Admin.Queries.IGetProduct _product;
        
//        #endregion

//        #region ctor
//        public AdminController(ISeedData data
//            ,ILogIn logIn, IGetCustomer customer, IDeactiveUser deactiveUser,
//             IMapper mapper, IGetCustomers customers, IEditSeller editSeller
//            , IEditCustomer editCustomer, IGetSellers sellers
//            , IGetSeller seller, IGetAllSellerProducts sellerProducts
//            , IGetSellerPavilions sellerPavilions, IGetAllAuctions auctions
//            , IGetAllPaidOrders paidOrders, IEditProduct editProduct
//            , AppService.Admin.Queries.IGetProduct product, IGetAuction getAuction,
//             IDeactiveProduct deactiveProduct, IActiveProduct activeProduct)
//        {
//            _data = data;
//            _mapper = mapper;
//            _logIn = logIn;
//            _customers = customers;
//            _customer = customer;
//            _editCustomer = editCustomer;
//            _sellers = sellers;
//            _editSeller = editSeller;
//            _seller = seller;
//            _deactiveUser = deactiveUser;
           

//            _sellerProducts = sellerProducts;
//            _sellerPavilions = sellerPavilions;
//            _auctions = auctions;
//            _paidOrders = paidOrders;
//            _product = product;
//            _deactiveProduct = deactiveProduct;
//            _editProduct = editProduct;
//            _activeProduct = activeProduct;
//            _getAuction = getAuction;
//        }
//        #endregion

//        // GET: /<controller>/
//        public IActionResult Index()
//        {
//            return View();
//        }




        
//        public async Task<IActionResult> ProductProfile(int id, CancellationToken cancellation)
//        {
//            DetailedProductDto detailedProduct = await _product.Execute(id, cancellation);
//            return View(detailedProduct);
//        }

//        [HttpPost]
//        public async Task<IActionResult> ProductProfile(DetailedProductDto productDto, CancellationToken cancellation)
//        {
//            if(await _editProduct.Execute(productDto,cancellation))
//            {
//                return RedirectToAction("ProductProfile", new { productDto.Id });
//            }
//            return View(productDto);
//        }

//        public async Task<IActionResult> AuctionProfile(int id, CancellationToken cancellation)
//        {
//           var detailedProduct = await _getAuction.Execute(id, cancellation);
//            return View(detailedProduct);
//        }

//        [HttpPost]
//        public async Task<IActionResult> AuctionProfile(DetailedProductDto productDto, CancellationToken cancellation)
//        {
//            if (await _editProduct.Execute(productDto, cancellation))
//            {
//                return RedirectToAction("ProductProfile", new { productDto.Id });
//            }
//            return View(productDto);
//        }


        


//        public async Task<IActionResult> GetOrdersList(CancellationToken cancellation)
//        {
//            List<DetailedDirctOrderDto> dirctOrderDtos = await _paidOrders.Execute(cancellation);
//            List<DetailedAuctionDto> auctionDtos = await _auctions.Execute(cancellation);
//            ViewBag.directOrderDtos = dirctOrderDtos; 
//            return View(auctionDtos);
//        }




//    }
//}

