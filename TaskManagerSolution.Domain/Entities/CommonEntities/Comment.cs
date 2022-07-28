using TaskManagerSolution.Domain.Entities.AuthEntities;

namespace TaskManagerSolution.Domain.Entities.CommonEntities;

public class Comment
{
    public int Id { get; set; }
    public string CommentText { get; set; }
    public virtual Comment ParentComment { get; set; }
    public int? ParentCommentId { get; set; }
    //برای نمایش زیر دسته های هر پیام
    public virtual ICollection<Comment> SubComments { get; set; }
    public virtual User User { get; set; }
    public int UserId { get; set; }
}