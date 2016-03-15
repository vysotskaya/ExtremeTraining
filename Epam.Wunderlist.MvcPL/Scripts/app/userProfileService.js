angular.module('wunderlistApp')
    .factory('userProfileService', function ($resource, WUNDERLIST_CONSTANTS) {
        var userProfile = {};

        function getUserProfile() {
            var resource = $resource(WUNDERLIST_CONSTANTS.URL + '/api/userprofile/', {},
            {
                get: {
                    method: 'GET',
                    isArray: false
                }
            });
            return resource.get.apply(this, arguments);
        }

        function updateUserProfileDataOnView(name, email, avatar) {
            userProfile.UserName = name;
            userProfile.Email = email;
            userProfile.Avatar = avatar;
        }

        function setUserProfileData(userProfileData) {
            userProfile.UserName = userProfileData.UserName;
            userProfile.Email = userProfileData.Email;
            userProfile.Avatar = "data:image/jpeg;base64," + userProfileData.Avatar;
        }

        function updateUserProfile(userProfile) {
            var resource = $resource(WUNDERLIST_CONSTANTS.URL + '/account/edit/', {},
            {
                save: {
                    method: 'POST',
                    transformRequest: angular.identity,
                    headers: { 'Content-Type': undefined }
                }
            });
            return resource.save.apply(this, arguments);
        }

        return {
            getUserProfile: getUserProfile,
            setUserProfileData: setUserProfileData,
            updateUserProfileDataOnView: updateUserProfileDataOnView,
            updateUserProfile: updateUserProfile,
            getUserProfileData: function () {
                return userProfile;
            }
        }
    });