//using BlazorSignalR.Server.Data;
//using BlazorSignalR.Server.hubs;
//using BlazorSignalR.Server.Utilities;
//using BlazorSignalR.Shared.Entities;
//using blazorSource.Server.Repository;
using AdminPanelIdentityServer.Server.Contract;
using AdminPanelIdentityServer.Shared.Dtos;
using Grpc.Core;
using GrpcData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSignalR.Server.Services
{


	public class DataServices : GrpcData.dataService.dataServiceBase
	{
		private readonly IClient clientRepository;

		public DataServices(IClient _clientRepository)
		{
			clientRepository = _clientRepository;
		}
		public async override Task<AddClientResponse> AddClient(AddClientRequest request, ServerCallContext context)
		{
			try
			{
				ClientDto dto = new ClientDto() { 
				 
					AllowedCorsOrigins=request.AllowedCorsOrigins,
					ClientId=request.ClientId,
					ClientName=request.ClientName,
					ClientSecrets=request.ClientSecrets,
					PostLogoutRedirectUris=request.PostLogoutRedirectUris,
					RedirectUris=request.RedirectUris
				};
				var res =await clientRepository.AddClient(dto);
				return new AddClientResponse() { Result = true};
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		//[Authorize]
		//public  override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
		//{
		//	var ss = context.GetHttpContext().Request.Headers["Authorization"];
		//	return Task.FromResult<HelloReply>(new HelloReply()
		//	{
		//		Message = $"hellow{request.Name}"
		//	});

		//}
		//	private readonly DataContext dataContext;
		//	private readonly IHubContext<FirstHub> hubContext;
		//	private readonly IuserRepopsitoryADO repopsitoryADO;
		//	private readonly IGeneratedToken generatedToken;

		//	public DataServices(DataContext dataContext,IHubContext<FirstHub> hubContext,IuserRepopsitoryADO repopsitoryADO, IGeneratedToken generatedToken)
		//	{
		//		this.dataContext = dataContext;
		//		this.hubContext = hubContext;
		//		this.repopsitoryADO = repopsitoryADO;
		//		this.generatedToken = generatedToken;
		//	}

		//	//[Authorize]
		//	public async override Task<GetBookRespons> GetBooks(Empty request, ServerCallContext context)
		//	{
		//		var books = await dataContext.TBook.ToListAsync();
		//		List<GetBookData> lst = new List<GetBookData>();
		//		GetBookRespons response = new GetBookRespons();
		//		foreach (var item in books)
		//		{
		//			GetBookData data = new GetBookData()
		//			{

		//				Author = item.Author,
		//				Name = item.Name,
		//				Price = item.Price,
		//				Isbn = item.Isbn,
		//				BookTitle = item.Name,
		//			};

		//			lst.Add(data);
		//		}

		//		response.BookList.Add(lst);
		//		return response;
		//	}


		//	public async override Task<AddBookDataResponse> AddBooks(AddBookDataRequest request, ServerCallContext context)
		//	{
		//		Random random = new Random();

		//		Book book = new Book()
		//		{

		//			Author = request.Author,
		//			Isbn = request.Isbn,
		//			Price = request.Price,
		//			Name = request.Name,
		//			Id = random.Next(1, 100).ToString()

		//		};

		//		await dataContext.TBook.AddAsync(book);
		//		await dataContext.SaveChangesAsync();
		//		//await hubContext.Clients.All.se
		//		return new AddBookDataResponse() { BookId = Convert.ToInt32(book.Id) };
		//	}

		//	public async override Task<EditBookResponse> Editbook(EditBookRequest request, ServerCallContext context)
		//	{
		//		try
		//		{

		//			var bookEdit = await dataContext.TBook.FirstOrDefaultAsync(a => a.Name == request.BookTitle);
		//			bookEdit.Name = request.NewTitle;
		//			bookEdit.Author = request.NewAuthor;
		//			bookEdit.Price= new Random().Next(1000, 100000); 
		//			dataContext.Entry<Book>(bookEdit).State = EntityState.Modified;
		//			await dataContext.SaveChangesAsync();
		//			return new EditBookResponse() { Result = true };
		//		}


		//		catch (Exception ex)
		//		{

		//			return new EditBookResponse() { Result = false };
		//		};

		//	}


		//	public async override Task<ChartResponse> manageChart(Empty request, ServerCallContext context)
		//	{
		//		//new LineChartData { xValue = new DateTime(2005, 01, 01), yValue = 21, yValue1 = 28 },

		//		List<Chart> charts = new List<Chart>() {

		//		new Chart() { XValue=Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow.AddYears(-1)), YValue =new Random().Next(10,100), YValue1 = new Random().Next(10,100)},
		//		new Chart() {XValue = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow.AddYears(-2)), YValue = new Random().Next(10,100), YValue1 = new Random().Next(10,100)},
		//		new Chart() {XValue = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow.AddYears(-3)), YValue = new Random().Next(10,100), YValue1 = new Random().Next(10,100)},
		//		new Chart() {XValue = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow.AddYears(-4)), YValue = new Random().Next(10,100), YValue1 = new Random().Next(10,100)},
		//		new Chart() {XValue = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow.AddYears(-5)), YValue = new Random().Next(10,100), YValue1 = new Random().Next(10,100)},
		//		new Chart() {XValue = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow.AddYears(-6)), YValue = new Random().Next(10,100), YValue1 = new Random().Next(10,100)},
		//		new Chart() {XValue = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.UtcNow.AddYears(-7)), YValue = new Random().Next(10,100), YValue1 = new Random().Next(10,100)},
		//		};

		//		ChartResponse chartResponse = new ChartResponse();
		//		chartResponse.ChartList.Add(charts);

		//		return chartResponse;
		//	}

		//	[AllowAnonymous]
		//	public async override Task<CreateTokenResponse> Createtoken(CreateTokenRequest request, ServerCallContext context)
		//	{
		//		try
		//		{
		//			var userLogin = await repopsitoryADO.GetUser(request.Username, request.Password);
		//			if (userLogin != null)
		//			{
		//				var token = await generatedToken.Execute(request.Username, request.Password);
		//				CreateTokenResponse createTokenResponse = new CreateTokenResponse()
		//				{

		//					Eroor = null,
		//					Token = token
		//				};
		//				return createTokenResponse;
		//			}

		//			else {

		//				CreateTokenResponse createTokenResponse = new CreateTokenResponse()
		//				{

		//					Eroor = "Usrername or password is not valid",
		//					Token = null
		//				};
		//				return createTokenResponse;

		//			}
		//		}
		//		catch (Exception ex)
		//		{

		//			CreateTokenResponse createTokenResponse = new CreateTokenResponse()
		//			{

		//				Eroor = "Usrername or password is not valid \n" + ex.Message,
		//				Token = null
		//			};
		//			return createTokenResponse;
		//		}


		//	}




		//public async override Task<GetBookRespons> GetBooksintractive(Empty request, ServerCallContext context)
		//{
		//	var books = await dataContext.TBook.ToListAsync();
		//	List<GetBookData> lst = new List<GetBookData>();
		//	GetBookRespons response = new GetBookRespons();
		//	foreach (var item in books)
		//	{
		//		var d= new Random().Next(1000, 100000); ;
		//		item.Price = d;
		//		dataContext.Entry<Book>(item).State = EntityState.Modified;
		//		await dataContext.SaveChangesAsync();
		//		GetBookData getBookData = new GetBookData() {

		//			Author = item.Author,
		//			BookTitle = item.Name,
		//			Name = item.Name,
		//			Isbn = item.Isbn,
		//			Price = d,
		//		};

		//		lst.Add(getBookData);
		//	}

		//	response.BookList.Add(lst);
		//	return response;
		//}


	}
}




	

	

