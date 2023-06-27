

using Forum.Data.Models;
using Forum.Services.Interfaces;
using Forum.ViewModels.Post;
using ForumApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Forum.Services
{
    public class PostService : IPostService
    {
        private readonly ForumDBContext dBContext;

        public PostService(ForumDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

		public async Task AddVoidAsync(PostAddFormModel postViewModel)
		{
            Post newPost = new Post()
            {
                Title = postViewModel.Title,
                Content = postViewModel.Content,
            };
            await this.dBContext.Posts.AddAsync(newPost);
            await this.dBContext.SaveChangesAsync();
		}

		public async Task DeleteByIdASync(string id)
		{
			Post postToDelete = await this.dBContext
                .Posts
                .FirstAsync(p => p.Id.ToString() == id);

            this.dBContext.Posts.Remove(postToDelete);
            await this.dBContext.SaveChangesAsync();
		}

		public async Task EditByIdASync(string id, PostAddFormModel postEditedModel)
		{
            Post postToEdit = await this.dBContext
                .Posts
                .FirstAsync(p => p.Id.ToString() == id);

            postToEdit.Title = postEditedModel.Title;
            postToEdit.Content = postEditedModel.Content;

            await this.dBContext.SaveChangesAsync();
		}

		public async Task<PostAddFormModel?> GetIdForEditOrDelete(string id)
		{
            Post? postToEdit = await this.dBContext
                .Posts
                .FirstOrDefaultAsync(p => p.Id.ToString() == id);

            if (postToEdit == null)
            {
                return null;
            }

            return new PostAddFormModel
            {
                Title = postToEdit.Title,
                Content = postToEdit.Content
            };
            
		}
        
		public async Task<IEnumerable<PostListViewModel>> ListAllAsync()
        {
            IEnumerable<PostListViewModel> allPosts = await dBContext
                .Posts
                .Select(p => new PostListViewModel()
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Content = p.Content
                })
                .ToArrayAsync();
            return allPosts;
        }
    }
}
