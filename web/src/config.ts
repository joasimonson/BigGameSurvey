import config from 'react-global-configuration';

var loaded = false;

export function init(): void {
    const configuration = {
        development: {
            URL_API: 'https://localhost:5001/api/'
        },
        test: {
            URL_API: 'https://localhost:5001/api/'
        },
        production: {
            URL_API: 'https://biggamesurvey.herokuapp.com/api/',
        }
    };

    let configs = configuration[process.env.NODE_ENV];

    config.set(configs);

    loaded = true;
}

export function getConfig(key: string): string {
    if (!loaded) {
        init();
    }

    return config.get(key);
}