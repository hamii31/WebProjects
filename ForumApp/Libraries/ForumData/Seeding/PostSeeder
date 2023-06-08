
using Forum.Data.Models;

namespace ForumApp.Data.Seeding
{
	class PostSeeder
	{
		internal Post[] GeneratePosts()
		{
			ICollection<Post> posts = new HashSet<Post>();
			Post currentPost;

			currentPost = new Post()
			{
				Title = "My First Post",
				Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed tempus egestas leo, in imperdiet neque dapibus non. Donec non efficitur. "
			};
			posts.Add(currentPost);

			currentPost = new Post()
			{
				Title = "My Second Post",
				Content = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."
			};
			posts.Add(currentPost);

			currentPost = new Post()
			{
				Title = "My Third Post",
				Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed quam lacus, accumsan sit amet enim non, euismod."
			};
			posts.Add(currentPost);

			return posts.ToArray();
		}
	}
}
