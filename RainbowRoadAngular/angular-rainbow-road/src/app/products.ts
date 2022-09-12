export interface Product {
    id: number;
    name: string;
    price: number;
    description: string;
  }
  
  export const products = [
    {
      id: 1,
      name: 'Red Bricks(x5)',
      price: 1,
      description: 'A deep scarlet three-dimensional rectangle made for any project'
    },
    {
      id: 2,
      name: 'Blue Brick(x5)',
      price: 1,
      description: 'Have you ever seen a cobalt brick?'
    },
    {
      id: 3,
      name: 'Yellow Brick(x5)',
      price: 1,
      description: 'Some say these bricks are straight from the land of Oz'
    }
  ];
  
  
  /*
  Copyright Google LLC. All Rights Reserved.
  Use of this source code is governed by an MIT-style license that
  can be found in the LICENSE file at https://angular.io/license
  */