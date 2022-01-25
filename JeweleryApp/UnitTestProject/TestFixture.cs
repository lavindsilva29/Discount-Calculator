using JeweleryApp.Models;
using System;
using System.Collections.Generic;

namespace UnitTestProject
{
    public class TestFixture  : IDisposable
    {
        public readonly List<UserModel> users = new List<UserModel>();
        public readonly List<GoldItem> goldItems = new List<GoldItem>();
        public readonly JeweleryDbContext context = null; // new JeweleryDbContext();

        public TestFixture()
        {
            SeedData();
        }

        public void Dispose()
        {

        }

        void SeedData()
        {
            users.Add(
                new UserModel
                {
                    UserId = "U01",
                    UserName = "User_01",
                    Password = "User@123"
                });

            users.Add(
                new UserModel
                {
                    UserId = "Admin",
                    UserName = "Administrator",
                    Password = "Admin@123"
                });

            goldItems.Add(
                new GoldItem
                {
                    Price = 1000,
                    Weight = 10,
                    Discount = 5
                });

            goldItems.Add(
                new GoldItem
                {
                    Price = 2000,
                    Weight = 20,
                    Discount = 10
                });
        }
    }
}
