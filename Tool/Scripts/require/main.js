require.config({
 
     //  псевдонимы и пути используемых библиотек и плагинов
     paths: {
         'angular': './angular'
     },
 
     // angular не поддерживает AMD из коробки, поэтому экспортируем перменную angular в глобальную область
     shim: {
         'angular': {
             exports: 'angular'
         }
     },
 
     // запустить приложение
     deps: ['./bootstrap']
});