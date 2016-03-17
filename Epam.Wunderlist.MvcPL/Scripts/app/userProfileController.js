angular.module('wunderlistApp')
    .controller('editUserProfileController', function($scope, $rootScope, fileReader, userProfileService) {

        $scope.userProfile = {};

        $rootScope.setUserProfileData = function() {
            var userProfile = userProfileService.getUserProfileData();
            $scope.imageSrc = userProfile.Avatar;
            $scope.userProfile.UserName = userProfile.UserName;
            $scope.userProfile.Email = userProfile.Email;
        }

        $scope.getFile = function() {
            fileReader.readAsDataUrl($scope.file, $scope)
                .then(function(result) {
                    $scope.imageSrc = result;
                });
        };

        $scope.updateUserProfile = function() {
            if ($scope.userProfile.UserName == "") {
                return;
            }
            console.log($scope.userProfile);
            var userProfile = new FormData();
            userProfile.append('Avatar', $scope.userProfile.Avatar);
            userProfile.append('UserName', $scope.userProfile.UserName);
            userProfileService.updateUserProfile(userProfile);

            userProfileService.updateUserProfileDataOnView($scope.userProfile.UserName,
                $scope.userProfile.Email, $scope.imageSrc);
            $rootScope.$broadcast('handleUserProfileChange');
        }
    })
    .directive("ngFileSelect", function() {
        return {
            link: function($scope, el) {
                el.bind("change", function(e) {
                    $scope.file = (e.srcElement || e.target).files[0];
                    if ($scope.file.type.match('image.*')) {
                        $scope.userProfile.Avatar = $scope.file;
                        $scope.getFile();
                    }
                });

            }
        };
    })
    .controller('userProfileController', function($scope, $rootScope) {
        $scope.prepareUserProfileModalForEdit = function() {
            $rootScope.setUserProfileData();
        }
    });