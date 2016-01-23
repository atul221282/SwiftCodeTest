/*
 * @description Main app module
 */
angular.module("mainModule", ["blockUI"]);

/*
 * @description Configuration for main app module
 */
angular.module("mainModule").config(config);
config.$inject = ["blockUIConfig"];
function config(blockUIConfig) {
    //nice library to display message 
    //but block it by default we need to use it manually
    blockUIConfig.autoBlock = false;
}

