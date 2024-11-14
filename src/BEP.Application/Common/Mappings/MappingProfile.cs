using AutoMapper;
using BEP.Application.Books.Commands;
using BEP.Domain.Filter;
using BEP.Application.Posts.Commands;
using BEP.Application.Users.Commands;
using BEP.Domain.DTOs;
using BEP.Domain.Models;
using BEP.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using BEP.Application.Posts.Queries;
using BEP.Application.Authors.Commands;
using BEP.Application.Books.Events;
using BEP.Application.WishList.Queries;
using BEP.Application.Users.Queries;
using BEP.Application.Request.Commands;
using BEP.Application.Deals.Commands;
using BEP.Application.Deals.Queries;
using BEP.Application.Request.Queries;
using BEP.Domain.ReadModel;

namespace BEP.Application.Common.Mappings
{
     public class MappingProfile : Profile
     {
          public MappingProfile()
          {
               CreateMap<Book, BookDto>();
               CreateMap<CreateBookCommand, Book>();
               CreateMap<BookDetails, BookDetailsDto>();

               CreateMap<Post, PostDto>();
               CreateMap<PostDto, Post>();
               CreateMap<CreatePostCommand, Post>();
               CreateMap<ReplacePostCommand, Post>();

               CreateMap<User, UserDto>();
               CreateMap<UserContact, UserContactDto>();


               CreateMap<BooksFilter, GetBooksQuery>();
               CreateMap<GetBooksQuery, PaginationFilter>();

               CreateMap<BooksFilter, GetUserWishedBooksQuery>();
               CreateMap<GetUserWishedBooksQuery, PaginationFilter>();

               CreateMap<PostsFilter, GetPostsQuery>();
               CreateMap<GetPostsQuery, PaginationFilter>();


               CreateMap<CreateAuthorDto, CreateAuthorCommand>();
               CreateMap<Author, AuthorDto>();

               CreateMap<Category, CategoryDto>();

               CreateMap<BookCreatedEvent, ReadModelBook>();

               CreateMap<Wishlist, WishListDto>();

               CreateMap<WishlistFilter, GetWishListAllQuery>();
               CreateMap<WishlistFilter, GetUserWishlistQuery>();
               CreateMap<GetWishListAllQuery, PaginationFilter>();
               CreateMap<GetUserWishlistQuery, PaginationFilter>();

               //CreateMap<Dea
               CreateMap<UpdateRequestDto, UpdateRequestCommand>();
               CreateMap<Domain.Models.Request, RequestDto>();

               CreateMap<UpdateDealDto, UpdateDealCommand>();
               CreateMap<Deal, DealDto>();

               CreateMap<PaginationFilter, GetDealsFromUserQuery>();
               CreateMap<PaginationFilter, GetDealsToUserQuery>();

               CreateMap<GetDealsFromUserQuery, PaginationFilter>();
               CreateMap<GetDealsToUserQuery, PaginationFilter>();

               CreateMap<GetRequestsToUserQuery, PaginationFilter>();
               CreateMap<GetRequestsFromUserQuery, PaginationFilter>();

               CreateMap<PaginationFilter, GetRequestsToUserQuery>();
               CreateMap<PaginationFilter, GetRequestsFromUserQuery>();

               CreateMap<GetUserPostsQuery, PaginationFilter>();
               CreateMap<PaginationFilter, GetUserPostsQuery>();

               CreateMap<User, TopUserDto>();
               CreateMap<GetLeaderboardDto, GetTopUsersQuery>();
          }
     }
}
