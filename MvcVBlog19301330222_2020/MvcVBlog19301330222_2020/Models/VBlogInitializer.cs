using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcVBlog19301330222_2020.Models
{
    public class VBlogInitializer : DropCreateDatabaseIfModelChanges<VBlogDBContext>
    {
        protected override void Seed(VBlogDBContext context)
        {
            var gbooks = new List<GuestBook>
            {
                new GuestBook(){
                    Nickname="大虾",
                    Message="网站很漂亮！",
                    AddDate=DateTime.Parse("2012-12-12 22:12:17")
                },
                new GuestBook(){
                    Nickname="过客",
                    Message="医生：“你太幸运了，你能康复全靠老天帮忙。”住院病人：“你说我康复是老天帮助？谢天谢地，本来我还以为要付钱给你呢？”",
                    AddDate=DateTime.Parse("2013-7-16 10:12:00"),
                    Reply="很好笑^_^"
                }
            };
            gbooks.ForEach(g => context.GuestBooks.Add(g));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category(){Name="日常小记"},
                new Category(){Name="技术交流"}
                
            };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var articles = new List<Article>
            {
                new Article(){
                    Title="长度的单位",
                    Content="在我读小学的时候，有一次上公开课，老师问我们一个问题：“各位同学，有谁知道长度的单位是什么啊？”这时候，班上最最乖巧的一个同学举手要求回答，这是课前老师安排好的，当然就的他回答啦。“老师，是米！”“不错不错，请坐下。”“可是，有谁还知道有什么呢？”这时候，平时学习最最落后的同学也举手，老师有点激动，虽然没有事先安排他，可是老师觉得不应该有歧视，决定给他一个机会。“老师，还有菜！”",
                    addDate=DateTime.Parse("2012-12-12"),
                    Hit=1,
                    CategoryID=1
                },
                new Article(){
                    Title="程序员餐厅",
                    Content="我真想开个程序员餐厅了，我当老板，进门时先写代码再进，一楼餐厅分C包间、java包间、linux/unix包间。搞开源软件的就坐大厅里，搞Ruby的上二楼。菜价全用十六进制，这样看着便宜。不知吃饭会不会吃到BUG。",
                    addDate=DateTime.Parse("2012-12-12"),
                    Hit=2,
                    CategoryID=1
                },
                new Article(){
                    Title="MVC模式",
                    Content="  MVC模式是一种软件架构模式。它把软件系统分为三个部分：模型（Model），视图（View）和控制器（Controller）。MVC模式最早由Trygve Reenskaug在1974年提出，是施乐帕罗奥多研究中心（Xerox PARC）在20世纪80年代为程序语言Smalltalk发明的一种软件设计模式。MVC模式的目的是实现一种动态的程序设计，使后续对程序的修改和扩展简化，并且使程序某一部分的重复利用成为可能。除此之外，此模式通过对复杂度的简化，使程序结构更加直观。软件系统通过对自身基本部份分离的同时也赋予了各个基本部分应有的功能。",
                    addDate=DateTime.Parse("2012-12-12"),
                    Hit=3,
                    CategoryID=2
                }
            };
            articles.ForEach(a => context.Articles.Add(a));
            context.SaveChanges();
        }
    }
}