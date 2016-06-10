/// <binding BeforeBuild='all' />
module.exports = function (grunt) {
    grunt.initConfig({
        clean: ["wwwroot/lib/"],
        copy: {
            main: {
                files: [
                    { expand: true, filter: "isFile", flatten: true, src: "bower_components/angular/angular.js", dest: "wwwroot/lib/angular/" },
                    { expand: true, filter: "isFile", flatten: true, src: "bower_components/angular-ui-router/release/angular-ui-router.js", dest: "wwwroot/lib/angular-ui-router/" },
                    { expand: true, filter: "isFile", flatten: true, src: "bower_components/ngprogress/build/ngprogress.js", dest: "wwwroot/lib/ng-progress/" }
                ]
            }
        }
    });

    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks("grunt-contrib-copy");
    grunt.registerTask("all", ["clean", "copy"]);
    grunt.registerTask("default", "all");
};