module.exports = function (grunt) {
    grunt.initConfig({
        clean: ["wwwroot/lib/"],
        copy: {
            main: {
                files: [
                    {
                        src: "bower_components/angular/angular.js",
                        dest: "wwwroot/lib/angular/",
                        expand: true,
                        filter: "isFile",
                        flatten: true
                    }
                ]
            }
        }
    });

    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks("grunt-contrib-copy");
    grunt.registerTask("all", ["clean", "copy"]);
    grunt.registerTask("default", "all");
};