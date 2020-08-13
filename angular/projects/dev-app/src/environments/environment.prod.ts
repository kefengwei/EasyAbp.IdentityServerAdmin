export const environment = {
  production: true,
  application: {
    name: 'IdentityServerAdmin',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44317',
    clientId: 'IdentityServerAdmin_ConsoleTestApp',
    dummyClientSecret: '1q2w3e*',
    scope: 'IdentityServerAdmin',
    showDebugInformation: true,
    oidc: false,
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44317',
    },
    IdentityServerAdmin: {
      url: 'https://localhost:44320',
    },
  },
};
