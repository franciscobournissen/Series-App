 import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44369/',
  redirectUri: baseUrl,
  clientId: 'SeriesApp_App',
  responseType: 'code',
  scope: 'offline_access SeriesApp',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'SeriesApp',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44369',
      rootNamespace: 'SeriesApp',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
