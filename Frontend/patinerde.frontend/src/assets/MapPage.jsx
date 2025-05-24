import { useEffect, useState } from 'react';
import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet';
import 'leaflet/dist/leaflet.css';
import '/src/assets/MapPage.css';
import L from 'leaflet';

// Marker ikonlarının doğru görünmesi için ayarlar
delete L.Icon.Default.prototype._getIconUrl;
L.Icon.Default.mergeOptions({
    iconRetinaUrl:
        'https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.7.1/images/marker-icon-2x.png',
    iconUrl:
        'https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.7.1/images/marker-icon.png',
    shadowUrl:
        'https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.7.1/images/marker-shadow.png',
});

const MapPage = () => {
    const [markers, setMarkers] = useState([]);

    useEffect(() => {
        fetch('https://localhost:7068/api/MapMaker/GetAll')
            .then((res) => res.json())
            .then((data) => {
                console.log("Gelen veriler:", data);
                setMarkers(data.items); // sadece items kısmını alıyoruz
            })
            .catch((err) => console.error("API Hatası:", err));
    }, []);

    return (
        <MapContainer
            center={[39.92, 32.85]}
            zoom={8}
            style={{ height: '600px', width: '1200px', borderRadius: '12px' ,  }}
        >
            <TileLayer
                attribution='&copy; OpenStreetMap contributors'
                url='https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png'
            />

            {markers.map((item, index) => (
                <Marker
                    key={index}
                    position={[item.enlem, item.boylam]}
                >
                    <Popup>
                        <strong>{item.title}</strong><br />
                        {item.description}
                    </Popup>
                </Marker>
            ))}
        </MapContainer>
    );
};

export default MapPage;
