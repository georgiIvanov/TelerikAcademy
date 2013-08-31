/// <reference path="../libs/underscore.js" />
/// <reference path="../libs/angular.js" />

angular.module("postsSPA", [])
	.config(["$routeProvider", function ($routeProvider) {
	    $routeProvider
			.when("/posts", { templateUrl: "Scripts/partials/all-posts.html", controller: PostsController })
			.when("/category/:categoryId/posts", { templateUrl: "Scripts/partials/single-post.html", controller: SinglePostController })
			.otherwise({ redirectTo: "/posts" });
	}]);
