select b.bookname, Genres.Genre, Authors.Author, Publishers.Publisher ,b.PublicationYear from Books b 
left join Genres on  b.GenreID=Genres.GenreID
left join Publishers on  Publishers.PublisherID=b.PublisherID
left join Authors on Authors.AuthorID=b.AuthorID where b.GenreID=16 