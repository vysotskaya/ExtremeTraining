angular.module('wunderlistApp').factory('userProfileService', function ($resource) {
    var userProfile = {};

    return {
        getUserProfile: function() {
            var resource = $resource('http://localhost:53028/api/userprofile/', {},
            {
                get: {
                    method: 'GET',
                    isArray: false
                }
            });
            return resource.get.apply(this, arguments);
        },

        setUserProfileData: function(userProfileData) {
            userProfile.UserName = userProfileData.UserName;
            userProfile.Email = userProfileData.Email;
            userProfile.Avatar = "data:image/jpeg;base64," + userProfileData.Avatar;
        },

        updateUserProfileDataOnView: function (name, email, avatar) {
            userProfile.UserName = name;
            userProfile.Email = email;
            userProfile.Avatar = avatar;
        },

        getUserProfileData: function () {
            return userProfile;
        },

        updateUserProfile: function (userProfile) {
            var resource = $resource('http://localhost:53028/account/edit/', {},
			{
			    save: {
			        method: 'POST',
			        transformRequest: angular.identity,
                    headers: { 'Content-Type': undefined }
                    //headers : {'Content-Type': 'application/x-www-form-urlencoded'}
			    }
			});
            return resource.save.apply(this, arguments);
        }

    }
});