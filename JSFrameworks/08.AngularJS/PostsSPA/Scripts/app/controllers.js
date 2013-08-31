/// <reference path="../libs/underscore.js" />
/// <reference path="persister.js" />
/// <reference path="../angular/angularjs.js" />

function PostsController($scope, $http) {
	$scope.newPost = {
		username: "",
		content: "",
		category: ""
	};

	persister.getPosts(function (data) {

	    $scope.posts = data.result;
	    $scope.categories = _.uniq(_.pluck(data.result, "Category"));
	    $scope.selectedCategory = $scope.categories[0];
	    $scope.$apply();

	}, function (err) {
	});

	$scope.addPost = function () {
	    persister.sendPost($scope.newPost, function (data) {
	        $scope.posts.push($scope.newPost);
	        var category = $scope.newPost.category;
	        if (!_.contains($scope.categories, category)) {
	        	$scope.categories.push(category);
	        }
	        $scope.$apply();
	    }, function (err) {

	    });

		$scope.newPost = {
		    username: "",
			content: "",
			category: ""
		};
	}

	
}

function SinglePostController($scope, $http, $routeParams) {
	var id = $routeParams.id;
	$http.get("scripts/data/posts.js")
	.success(function (posts) {
		var post = _.first(_.where(posts, { "id": parseInt(id) }));
		$scope.post = post;
	})
}

function CategoryController($scope, $http, $routeParams) {
	var categoryName = $routeParams.name;

	$http.get("scripts/data/posts.js")
	.success(function (posts) {
		var category = {
			name: categoryName,
			posts: []
		};
		_.chain(posts)
		.where({ "category": categoryName })
		.each(function (post) {
			category.posts.push({
				id: post.id,
				title: post.title,
				content: post.content
			});
		})
		$scope.category = category;
	})
};


//function PhoneListCtrl($scope) {
//    $scope.phones = [
//        {
//            "name": "Nexus S",
//            "snippet": "Fast just got faster with Nexus S.",
//            "age": 0
//        },
//        {
//            "name": "Motorola XOOM™ with Wi-Fi",
//            "snippet": "The Next, Next Generation tablet.",
//            "age": 3
//        },
//        {
//            "name": "MOTOROLA XOOM™",
//            "snippet": "The Next, Next Generation tablet.",
//            "age": 1
//        },
//        {
//            "name": "Samsung Galaxy S",
//            "snippet": "good phone",
//            "age": 2
//        }
//    ];

//    $scope.orderProp = 'age';
//}

//function PhoneDetailCtrl($scope, $routeParams) {
//    $scope.phoneId = $routeParams.phoneId;
//}

