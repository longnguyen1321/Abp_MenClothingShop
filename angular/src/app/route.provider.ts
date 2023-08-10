import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/men-clothing-shop',
        name: '::Menu:MenClothingShop',
        iconClass: 'fas fa-book',
        order: 2,
        layout: eLayoutType.application
      },
      {
        path: '/clothes',
        name: '::Menu:Clothes',
        parentName: '::Menu:MenClothingShop',
        layout: eLayoutType.application,
        requiredPolicy: 'MenClothingShop.Clothes',  
      },
      {
        path: '/exports',
        name: '::Menu:Exports',
        parentName: '::Menu:MenClothingShop',
        layout: eLayoutType.application,
        requiredPolicy: 'MenClothingShop.Exports'
      },
    ]);
  };
}
