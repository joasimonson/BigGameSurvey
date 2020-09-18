import React, { useEffect, useState } from "react";
import Chart from "react-apexcharts";

import Filters from "../../components/Filters";

import { barOptions, pieOptions } from "./chart-options";
import { BarChartData, PieChartData } from './types';
import { buildBarSeries, getGenderChartData, getPlatformChartData } from "./helpers";

import api from "../../services/api";

import './styles.css';

const initialPieData = {
    labels: [],
    series: []
}

const Charts = () => {
    const [barChartData, setBarChartData] = useState<BarChartData[]>([])
    const [platformData, setPlatformData] = useState<PieChartData>(initialPieData)
    const [genderData, setGenderData] = useState<PieChartData>(initialPieData)

    useEffect(() => {
        async function getDataCharts() {
            const recordsResponse = await api.get(`records`); // TODO: Arrumar paginação do backend
            const gamesResponse = await api.get(`games`);

            const barData = buildBarSeries(gamesResponse.data, recordsResponse.data.collection);
            setBarChartData(barData);

            const platformData = getPlatformChartData(recordsResponse.data.collection)
            setPlatformData(platformData);

            const genderData = getGenderChartData(recordsResponse.data.collection)
            setGenderData(genderData);
        }

        getDataCharts();
    }, [])

    return (
        <div className="page-container">
            <Filters link="/records" linkText="VER TABELA" />
            <div className="chart-container">
                <div className="top-related">
                    <h1 className="top-related-title">
                        Jogos mais votados
                    </h1>
                    <div className="games-container">
                        <Chart
                            options={barOptions}
                            type="bar"
                            width="900"
                            height="650"
                            series={[{ data: barChartData }]}
                        />
                    </div>
                </div>
                <div className="charts">
                    <div className="platform-chart">
                        <h2 className="chart-title">Plataformas</h2>
                        <Chart
                            options={{ ...pieOptions, labels: platformData?.labels }}
                            type="donut"
                            width="350"
                            series={platformData?.series}
                        />
                    </div>
                    <div className="genre-chart">
                        <h2 className="chart-title">Gêneros</h2>
                        <Chart
                            options={{ ...pieOptions, labels: genderData?.labels }}
                            type="donut"
                            width="350"
                            series={genderData?.series}
                        />
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Charts;