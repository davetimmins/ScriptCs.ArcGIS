'use strict';

module.exports = function (grunt) {

    require('load-grunt-tasks')(grunt);
    require('time-grunt')(grunt);

    grunt.initConfig({
        clean: ["dist"],
        shell: {
            makeDir: {
                command: 'mkdir dist'
            }
        },
        msbuild: {
            src: ['*.sln'],
            options: {
                projectConfiguration: 'Release',
                targets: ['Clean', 'Rebuild'],
                stdout: true
            }
        },
        nugetpack: {
            dist: {
                src: '*.nuspec',
                dest: 'dist/'
            }
        }
    });

    grunt.registerTask('default', ['clean', 'shell', 'msbuild', 'nugetpack']);
};
