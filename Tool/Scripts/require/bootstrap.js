define([
     'require',
     'angular',
     'app',
     'routes'
], function (require, ng) {
    'use strict';

    require(function (document) {
        ng.bootstrap(document, ['app']);
    });
});