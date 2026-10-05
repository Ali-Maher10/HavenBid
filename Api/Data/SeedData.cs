using Microsoft.EntityFrameworkCore;
public static class SeedData
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<HouseEntity>().HasData(new List<HouseEntity> {
            new HouseEntity {
                Id = 1,
                Address = "12 Valley of Kings, Geneva",
                Country = "Switzerland",
                Description = "A superb detached Victorian property on one of the town's finest roads, within easy reach of Barnes Village. The property has in excess of 6000 sq/ft of accommodation, a driveway and landscaped garden.",
                Price = 900000,
                Photo = "/houses/house-1.svg"
            },
            new HouseEntity
            {
                Id = 2,
                Address = "89 Road of Forks, Bern",
                Country = "Switzerland",
                Description = "This impressive family home, which dates back to approximately 1840, offers original period features throughout and is set back from the road with off street parking for up to six cars and an original Coach House, which has been incorporated into the main house to provide further accommodation. ",
                Price = 500000,
                Photo = "/houses/house-2.svg"
            },
            new HouseEntity
            {
                Id = 3,
                Address = "Grote Hof 12, Amsterdam",
                Country = "The Netherlands",
                Description = "This house has been designed and built to an impeccable standard offering luxurious and elegant living. The accommodation is arranged over four floors comprising a large entrance hall, living room with tall sash windows, dining room, study and WC on the ground floor.",
                Price = 200500,
                Photo = "/houses/house-3.svg"
            },
            new HouseEntity
            {
                Id = 4,
                Address = "Meel Kade 321, The Hague",
                Country = "The Netherlands",
                Description = "Discreetly situated a unique two storey period home enviably located on the corner of Krom Road and Recht Road offering seclusion and privacy. The house features a magnificent double height reception room with doors leading directly out onto a charming courtyard garden.",
                Price = 259500,
                Photo = "/houses/house-4.svg"
            },
            new HouseEntity
            {
                Id = 5,
                Address = "Oude Gracht 32, Utrecht",
                Country = "The Netherlands",
                Description = "This luxurious three bedroom flat is contemporary in style and benefits from the use of a gymnasium and a reserved underground parking space.",
                Price = 400500,
                Photo = "/houses/house-5.svg"
            },
            new HouseEntity
            {
                Id = 101,
                Address = "Via dei Tigli 8, Lugano",
                Country = "Switzerland",
                Description = "A bright lakeside villa with a terraced garden, a covered loggia and views across the water. Three bedrooms, a study and a private mooring a short walk away.",
                Price = 780000,
                Photo = "/houses/house-6.svg"
            },
            new HouseEntity
            {
                Id = 102,
                Address = "Strandweg 14, Zandvoort",
                Country = "The Netherlands",
                Description = "A white coastal house two minutes from the beach, with a sun deck on the top floor, an open kitchen and a storage room for bikes and boards.",
                Price = 545000,
                Photo = "/houses/house-7.svg"
            },
            new HouseEntity
            {
                Id = 103,
                Address = "Rue des Alpes 3, Zermatt",
                Country = "Switzerland",
                Description = "A timber-clad mountain cabin with a stone fireplace, a ski room and a south-facing balcony. Sleeps eight and is rented out in winter.",
                Price = 1250000,
                Photo = "/houses/house-8.svg"
            },
            new HouseEntity
            {
                Id = 104,
                Address = "Calle del Sol 27, Valencia",
                Country = "Spain",
                Description = "A renovated terracotta townhouse with a courtyard, original tile floors and a roof terrace. Close to the old town and the metro.",
                Price = 365000,
                Photo = "/houses/house-9.svg"
            },
            new HouseEntity
            {
                Id = 105,
                Address = "Königsallee 90, Düsseldorf",
                Country = "Germany",
                Description = "A modern four-bedroom house with floor-to-ceiling glazing, a heated double garage and a quiet garden on a tree-lined street.",
                Price = 890000,
                Photo = "/houses/house-10.svg"
            }
        });
        builder.Entity<BidEntity>().HasData(new List<BidEntity>
        {
            new BidEntity { Id = 1, HouseId = 1, Bidder = "Sonia Reading", Amount = 200000 },
            new BidEntity { Id = 2, HouseId = 1, Bidder = "Dick Johnson", Amount = 202400 },
            new BidEntity { Id = 3, HouseId = 2, Bidder = "Mohammed Vahls", Amount = 302400 },
            new BidEntity { Id = 4, HouseId = 2, Bidder = "Jane Williams", Amount = 310500 },
            new BidEntity { Id = 5, HouseId = 2, Bidder = "John Kepler", Amount = 315400 },
            new BidEntity { Id = 6, HouseId = 3, Bidder = "Bill Mentor", Amount = 201000 },
            new BidEntity { Id = 7, HouseId = 4, Bidder = "Melissa Kirk", Amount = 410000 },
            new BidEntity { Id = 8, HouseId = 4, Bidder = "Scott Max", Amount = 450000 },
            new BidEntity { Id = 9, HouseId = 4, Bidder = "Christine James", Amount = 470000 },
            new BidEntity { Id = 10, HouseId = 5, Bidder = "Omesh Carim", Amount = 450000 },
            new BidEntity { Id = 11, HouseId = 5, Bidder = "Charlotte Max", Amount = 150000 },
            new BidEntity { Id = 12, HouseId = 5, Bidder = "Marcus Scott", Amount = 170000 },
            new BidEntity { Id = 101, HouseId = 101, Bidder = "Elena Rossi", Amount = 760000 },
            new BidEntity { Id = 102, HouseId = 102, Bidder = "Daan de Vries", Amount = 530000 },
            new BidEntity { Id = 103, HouseId = 103, Bidder = "Anna Keller", Amount = 1200000 },
            new BidEntity { Id = 104, HouseId = 104, Bidder = "Carlos Mena", Amount = 350000 },
            new BidEntity { Id = 105, HouseId = 105, Bidder = "Jonas Weber", Amount = 870000 },
        });
    }
}
