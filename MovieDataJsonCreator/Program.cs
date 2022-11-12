﻿using MovieDataJsonCreator;

var source = "D:\\baza_filmow.txt";
var dest = "D:\\baza_filmow.json";
var parser = new FileParser(source);
var movies = parser.GetMovies();
var writer = new FileWritter(dest, movies);
writer.SaveFile();