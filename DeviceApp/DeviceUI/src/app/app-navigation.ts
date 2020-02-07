export const navigation = [
  {
    text: 'Home',
    path: '/home',
    icon: 'home'
  },
  {
    text: 'Examples',
    icon: 'folder',
    items: [
      {
        text: 'Users',
        path: '/users'
      },
      {
        text: 'Devices',
        icon: 'folder',
        items: [
          {
            text: 'Devices',
            path: '/devices'
          },
          
          {
            text: 'Device Category',
            path: '/devicecategories'
          },
        ]
      },
      {
        text: 'Test',
        path: '/test'
      },
      {
        text: 'Profile',
        path: '/profile'
      },
      {
        text: 'Display Data',
        path: '/display-data'
      }
    ]
  }
];
