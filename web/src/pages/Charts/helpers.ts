import { Game } from "../../types/model";
import { RecordResponseItem } from "../Records/types";

export const buildBarSeries = (games: Game[], records: RecordResponseItem[]) => {
  const mappedGames = games.map((game) => {
    const filteredGames = records.filter((item) => {
      return (
        item.game.title === game.title && item.game.platform === game.platform
      );
    });

    return{
      x: `${game.title} | ${game.platform}`,
      y: filteredGames.length,
    };
  });

  const sortedGames = mappedGames.sort((a, b) => {
    return b.y - a.y;
  });

  return sortedGames.slice(0, 8);
};

export const getPlatformChartData = (records: RecordResponseItem[]) => {
  const platforms = ["PC", "PLAYSTATION", "XBOX"];

  const series = platforms.map((platform) => {
    const filteredGames = records.filter((item) => {
      return platform === item.game.platform;
    });

    return filteredGames.length;
  });

  return {
    labels: platforms,
    series,
  };
};

export const getGenderChartData = (records: RecordResponseItem[]) => {
  const genderByAmount = records.reduce((accumulator, currentValue) => {
    if (accumulator[currentValue.genre.name] !== undefined) {
      accumulator[currentValue.genre.name] += 1;
    } else {
      accumulator[currentValue.genre.name] = 1;
    }

    return accumulator;
  }, {} as Record<string, number>);

  const labels = Object.keys(genderByAmount);
  const series = Object.values(genderByAmount);

  return {
    labels,
    series,
  };
};