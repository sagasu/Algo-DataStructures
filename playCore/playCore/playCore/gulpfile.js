/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
concat = require('gulp-concat');
cssmin = require('gulp-cssmin');
uglify = require('gulp-uglify');

var paths = {
    webroot: "./wwwroot/"
};


paths.bootstrapCss = "./bower_components/bootstrap/dist/css/bootstrap.css";
paths.sbAdminCss = "./bower_components/startbootstrap-sb-admin-2/dist/css/sb-admin-2.css";
paths.fontAwesomeCss = "./bower_components/font-awesome/css/font-awesome.css";
paths.morrisCss = "./bower_components/morrisjs/morris.css";

paths.jqueryJs = "./bower_components/jquery/dist/jquery.js";
paths.raphaelJs = "./bower_components/raphael/raphael.js";
paths.morrisJs = "./bower_components/morrisjs/morris.js";

paths.fonts = "./bower_components/font-awesome/fonts/*";

paths.jsDest = paths.webroot + "js";
paths.cssDest = paths.webroot + "css";
paths.fontDest = paths.webroot + "css/fonts";


gulp.task('default', function () {
    // place code for your default task here
});